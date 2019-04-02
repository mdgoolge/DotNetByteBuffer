using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetByteBuffer
{
    public class ByteBuffer
    {
        int mark;
        int position;
        int limit;
        int capacity;

        byte[] hb;

        #region 构造
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ByteBuffer()
        {
            capacity = 1024;

            hb = new byte[capacity];
            position = 0;
            limit = capacity;
            mark = -1;
            IsLittleEndian = BitConverter.IsLittleEndian;
        }

        /// <summary>
        /// 构造指定大小的buffer
        /// </summary>
        /// <param name="len">buffer容量</param>
        public ByteBuffer(int c)
        {
            capacity = c;
            hb = new byte[capacity];
            position = 0;
            limit = capacity;
            mark = -1;
            IsLittleEndian = BitConverter.IsLittleEndian;
        }





        #endregion

        /// <summary>
        /// 初始化ByteBuffer的每一个元素,并把当前指针指向头一位
        /// </summary>

        public int Position { get { return position; } set { position = value; } }

        public bool IsLittleEndian { get; set; }

        public byte[] Data
        {
            get
            {
                byte[] ba = new byte[Remaining()];
                Array.Copy(hb, position, ba, 0, ba.Length);
                return ba;

            }
        }
        public byte[] ArrayHb { get { return hb; } }
        public ByteBuffer Flip()
        {
            limit = position;
            position = 0;
            mark = -1;
            return this;
        }

        public ByteBuffer Clear()
        {
            position = 0;
            limit = capacity;
            mark = -1;
            return this;
        }
        public void PositionSet(int p) { Position = p; }
        int NextPutIndex()
        {
            if (position >= limit) throw new Exception("BufferOverflow");
            return position++;
        }

        int NextPutIndex(int nb)
        {
            if (limit - position < nb) throw new Exception("BufferOverflow");
            int p = position;
            position += nb;
            return p;
        }

        /// <summary>
        /// 检测索引位置
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        int CheckIndex(int i)
        {
            if ((i < 0) || (i >= limit)) throw new Exception("IndexOutOfBoundsException");
            return i;
        }
        /// <summary>
        /// 检测索引位置，和索引结尾
        /// </summary>
        /// <param name="i"></param>
        /// <param name="nb"></param>
        /// <returns></returns>
        int CheckIndex(int i, int nb)
        {
            if ((i < 0) || (nb > limit - i)) throw new Exception("IndexOutOfBoundsException");
            return i;
        }


        int NextGetIndex()
        {
            if (position >= limit) throw new Exception("BufferUnderflowException");

            return position++;
        }

        int NextGetIndex(int nb)
        {
            if (limit - position < nb) throw new Exception("BufferUnderflowException");
            int p = position;
            position += nb;
            return p;
        }

        static void CheckBounds(int off, int len, int size)
        {
            if ((off | len | (off + len) | (size - (off + len))) < 0) throw new Exception("IndexOutOfBoundsException");
        }
        public int Remaining()
        {
            return limit - position;
        }
        /**
    * Sets this buffer's limit.  If the position is larger than the new limit
    * then it is set to the new limit.  If the mark is defined and larger than
    * the new limit then it is discarded.
    *
    * @param  newLimit
    *         The new limit value; must be non-negative
    *         and no larger than this buffer's capacity
    *
    * @return  This buffer
    *
    * @throws  IllegalArgumentException
    *          If the preconditions on <tt>newLimit</tt> do not hold
    */
        public ByteBuffer SetLimit(int newLimit)
        {
            if ((newLimit > capacity) || (newLimit < 0)) throw new Exception("IllegalArgumentException");
            limit = newLimit;
            if (position > limit) position = limit;
            if (mark > limit) mark = -1;
            return this;
        }
        /**
     * Tells whether there are any elements between the current position and
     * the limit.
     *
     * @return  <tt>true</tt> if, and only if, there is at least one element
     *          remaining in this buffer
     */
        public bool HasRemaining
        {
            get { return position < limit; }
        }

        //public override string ToString()
        //{
        //    byte[] ba = new byte[limit];
        //    Get(ba, 0, limit, 0);
        //    return BitConverter.ToString(ba);
        //}


        #region byte
        public void _Put(int i, byte b)
        {
            hb[i] = b;
        }
        public byte _Get(int i)
        {
            return hb[i];
        }


        public ByteBuffer Put(byte x)
        {
            hb[NextPutIndex()] = x;
            return this;
        }

        public ByteBuffer Put(int i, byte x)
        {
            hb[CheckIndex(i)] = x;
            return this;
        }


        public byte Get()
        {
            return hb[NextGetIndex()];
        }

        public byte Get(int i)
        {
            return hb[CheckIndex(i)];
        }
        #endregion

        #region byte[]
        public ByteBuffer Put(byte[] src, int offset, int length)
        {
            CheckBounds(offset, length, src.Length);
            if (length > Remaining()) throw new Exception("BufferOverflowException");

            Array.Copy(src, offset, hb, NextPutIndex(length), length);

            return this;
        }
        public ByteBuffer Put(byte[] src, int offset, int length, int bbstart)
        {
            CheckBounds(offset, length, src.Length);
            if (length > Remaining()) throw new Exception("BufferOverflowException");

            Array.Copy(src, offset, hb, bbstart, length);

            return this;
        }
        public ByteBuffer Put(byte[] src)
        {
            return Put(src, 0, src.Length);
        }

        public ByteBuffer Get(byte[] dst, int offset, int length)
        {
            if (length > Remaining()) throw new Exception("BufferUnderflowException");
            return Get(dst, offset, length, NextGetIndex(length));
        }
        public ByteBuffer Get(byte[] dst, int offset, int length, int bbstart)
        {
            CheckBounds(offset, length, dst.Length);
            if (bbstart < 0 | bbstart >= capacity | bbstart + length > capacity) throw new Exception("BufferUnderflowException");
            Array.Copy(hb, bbstart, dst, offset, length);

            return this;
        }





        #endregion

        #region short
        public ByteBuffer PutShort(short x)
        {
            Bits.PutShort(this, NextPutIndex(2), x);
            return this;
        }

        public ByteBuffer PutShort(int i, short x)
        {
            Bits.PutShort(this, CheckIndex(i, 2), x);
            return this;
        }

        public short GetShort()
        {
            return Bits.GetShort(this, NextGetIndex(2));
        }

        public short GetShort(int i)
        {
            return Bits.GetShort(this, CheckIndex(i, 2));
        }
        #endregion

        #region int
        public ByteBuffer PutInt(int x)
        {
            Bits.PutInt(this, NextPutIndex(4), x);
            return this;
        }

        public ByteBuffer PutInt(int i, int x)
        {
            Bits.PutInt(this, CheckIndex(i, 4), x);
            return this;
        }

        public int GetInt()
        {
            return Bits.GetInt(this, NextGetIndex(4));
        }

        public int GetInt(int i)
        {
            return Bits.GetInt(this, CheckIndex(i, 4));
        }
        #endregion

        #region UInt32
        public ByteBuffer PutUInt32(UInt32 x)
        {
            Bits.PutUInt32(this, NextPutIndex(4), x);
            return this;
        }

        public ByteBuffer PutUInt32(int i, UInt32 x)
        {
            Bits.PutUInt32(this, CheckIndex(i, 4), x);
            return this;
        }

        public UInt32 GetUInt32()
        {
            return Bits.GetUInt32(this, NextGetIndex(4));
        }

        public UInt32 GetUInt32(int i)
        {
            return Bits.GetUInt32(this, CheckIndex(i, 4));
        }
        #endregion

        #region long
        public ByteBuffer PutLong(long x)
        {
            Bits.PutLong(this, NextPutIndex(8), x);
            return this;
        }

        public ByteBuffer PutLong(int i, long x)
        {
            Bits.PutLong(this, CheckIndex(i, 8), x);
            return this;
        }

        public long GetLong()
        {
            return Bits.GetLong(this, NextGetIndex(8));
        }

        public long GetLong(int i)
        {
            return Bits.GetLong(this, CheckIndex(i, 8));
        }
        #endregion

        #region float
        /// <summary>
        /// 写入，单精度浮点数32位
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ByteBuffer PutFloat(float x)
        {
            Bits.PutFloat(this, NextPutIndex(4), x);
            return this;
        }
        /// <summary>
        /// 写入，单精度浮点数32位，在指定位置
        /// </summary>
        /// <param name="i">指定的位置</param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ByteBuffer PutFloat(int i, float x)
        {
            Bits.PutFloat(this, CheckIndex(i, 4), x);
            return this;
        }

        public float GetFloat()
        {
            return Bits.GetFloat(this, NextGetIndex(4));
        }

        public float GetFloat(int i)
        {
            return Bits.GetFloat(this, CheckIndex(i, 4));
        }

        public ByteBuffer GetFloat(float[] dst, int offset, int length)
        {
            CheckBounds(offset, length, dst.Length);
            if (length * 4 > Remaining()) throw new Exception("BufferOverflowException");

            for (int i = 0; i < length; i++)
            {
                dst[i + offset] = GetFloat();
            }

            return this;
        }
        #endregion

        #region double
        /// <summary>
        /// 写入，双精度浮点数64位
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public ByteBuffer PutDouble(double x)
        {
            Bits.PutDouble(this, NextPutIndex(8), x);
            return this;
        }
        /// <summary>
        /// 写入，双精度浮点数64位，在指定位置
        /// </summary>
        /// <param name="i">指定的位置</param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ByteBuffer PutDouble(int i, double x)
        {
            Bits.PutDouble(this, CheckIndex(i, 8), x);
            return this;
        }

        public double GetDouble()
        {
            return Bits.GetDouble(this, NextGetIndex(8));
        }

        public double GetDouble(int i)
        {
            return Bits.GetDouble(this, CheckIndex(i, 8));
        }
        #endregion

        #region ByteBuffer
        public ByteBuffer PutByteBuffer(ByteBuffer bb)
        {
            Put(bb.Data);
            return this;
        }
        #endregion


        public string CurrentInfo()
        {
            string result = "capacity:" + string.Format("{0,15}", capacity);
            result += ",";
            result += "position:" + string.Format("{0,15}", position);
            result += ",";
            result += "limit:" + string.Format("{0,15}", limit);
            result += ",";
            result += "mark:" + string.Format("{0,15}", mark);
            result += ",";
            result += "IsLittleEndian:" + string.Format("{0,15}", IsLittleEndian);
            result += ",";
            result += "Data.Length:" + string.Format("{0,15}", Data.Length);

            return result;
        }
    }
}
