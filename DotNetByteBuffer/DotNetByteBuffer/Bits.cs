using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetByteBuffer
{
    public class Bits
    {
        public static byte int3(int x) { return (byte)(x >> 24); }
        public static byte int2(int x) { return (byte)(x >> 16); }
        public static byte int1(int x) { return (byte)(x >> 8); }
        public static byte int0(int x) { return (byte)(x); }



        #region Converter
        public static byte[] GetBytes(short v, bool IsLittleEndian = true)
        {
            byte[] bs = BitConverter.GetBytes(v);

            if (IsLittleEndian)
            {
                if (!BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }
            else
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }

            return bs;
        }
        /// <summary>
        /// 获取字节，整型32位
        /// </summary>
        /// <param name="v"></param>
        /// <param name="IsLittleEndian">true=LittleEndian,false=BigEndian</param>
        /// <returns></returns>
        public static byte[] GetBytes(int v, bool IsLittleEndian = true)
        {
            byte[] bs = BitConverter.GetBytes(v);

            if (IsLittleEndian)
            {
                if (!BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }
            else
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }

            return bs;
        }
        /// <summary>
        /// 获取字节，整型32位无符号
        /// </summary>
        /// <param name="v"></param>
        /// <param name="IsLittleEndian"></param>
        /// <returns></returns>
        public static byte[] GetBytes(UInt32 v, bool IsLittleEndian = true)
        {
            byte[] bs = BitConverter.GetBytes(v);

            if (IsLittleEndian)
            {
                if (!BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }
            else
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }

            return bs;
        }
        /// <summary>
        /// 获取字节，长整型
        /// </summary>
        /// <param name="v"></param>
        /// <param name="IsLittleEndian">true=LittleEndian,false=BigEndian</param>
        /// <returns></returns>
        public static byte[] GetBytes(long v, bool IsLittleEndian = true)
        {
            byte[] bs = BitConverter.GetBytes(v);

            if (IsLittleEndian)
            {
                if (!BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }
            else
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }

            return bs;
        }
        /// <summary>
        /// 获取字节，长整型
        /// </summary>
        /// <param name="v"></param>
        /// <param name="IsLittleEndian">true=LittleEndian,false=BigEndian</param>
        /// <returns></returns>
        public static byte[] GetBytes(float v, bool IsLittleEndian = true)
        {
            byte[] bs = BitConverter.GetBytes(v);

            if (IsLittleEndian)
            {
                if (!BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }
            else
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }

            return bs;
        }
        public static byte[] GetBytes(double v, bool IsLittleEndian = true)
        {
            byte[] bs = BitConverter.GetBytes(v);

            if (IsLittleEndian)
            {
                if (!BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }
            else
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bs);
                }
            }

            return bs;
        }


        public static short ToShort(byte[] ba, bool isLittleEndian = true)
        {
            byte[] batmp = new byte[ba.Length];
            Array.Copy(ba, 0, batmp, 0, ba.Length);
            if (isLittleEndian != BitConverter.IsLittleEndian)
            {
                Array.Reverse(batmp);
            }

            return BitConverter.ToInt16(batmp, 0);
        }
        public static int ToInt(byte[] ba, bool isLittleEndian = true)
        {
            byte[] batmp = new byte[ba.Length];
            Array.Copy(ba, 0, batmp, 0, ba.Length);
            if (isLittleEndian != BitConverter.IsLittleEndian)
            {
                Array.Reverse(batmp);
            }

            return BitConverter.ToInt32(batmp, 0);
        }
        public static UInt32 ToUInt32(byte[] ba, bool isLittleEndian = true)
        {
            byte[] batmp = new byte[ba.Length];
            Array.Copy(ba, 0, batmp, 0, ba.Length);
            if (isLittleEndian != BitConverter.IsLittleEndian)
            {
                Array.Reverse(batmp);
            }

            return BitConverter.ToUInt32(batmp, 0);
        }
        public static long ToLong(byte[] ba, bool isLittleEndian = true)
        {
            byte[] batmp = new byte[8];
            Array.Copy(ba, 0, batmp, 0, ba.Length);
            if (isLittleEndian != BitConverter.IsLittleEndian)
            {
                Array.Reverse(batmp);
            }

            return BitConverter.ToInt64(batmp, 0);
        }
        public static float ToFloat(byte[] ba, bool isLittleEndian = true)
        {
            byte[] batmp = new byte[4];
            Array.Copy(ba, 0, batmp, 0, ba.Length);
            if (isLittleEndian != BitConverter.IsLittleEndian)
            {
                Array.Reverse(batmp);
            }

            return BitConverter.ToSingle(batmp, 0);
        }
        public static double ToDouble(byte[] ba, bool isLittleEndian = true)
        {
            byte[] batmp = new byte[8];
            Array.Copy(ba, 0, batmp, 0, ba.Length);
            if (isLittleEndian != BitConverter.IsLittleEndian)
            {
                Array.Reverse(batmp);
            }

            return BitConverter.ToDouble(batmp, 0);
        }
        #endregion

        #region short
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bb"></param>
        /// <param name="bbindex">在ByteBuffer要存放的起始地址</param>
        /// <param name="value"></param>
        public static void PutShort(ByteBuffer bb, int bbindex, short value)
        {
            byte[] ba = GetBytes(value, bb.IsLittleEndian);
            bb.Put(ba, 0, ba.Length, bbindex);
        }
        public static short GetShort(ByteBuffer bb, int bbindex)
        {
            byte[] batmp = new byte[2];
            bb.Get(batmp, 0, 2, bbindex);
            return ToShort(batmp, bb.IsLittleEndian);
        }

        #endregion

        #region int

        public static void PutInt(ByteBuffer bb, int bbindex, int value)
        {
            byte[] ba = GetBytes(value, bb.IsLittleEndian);
            bb.Put(ba, 0, ba.Length, bbindex);
        }
        public static int GetInt(ByteBuffer bb, int bbindex)
        {
            byte[] batmp = new byte[4];
            bb.Get(batmp, 0, 4, bbindex);
            return ToInt(batmp, bb.IsLittleEndian);
        }
        #endregion
        #region UInt32

        public static void PutUInt32(ByteBuffer bb, int bbindex, UInt32 value)
        {
            byte[] ba = GetBytes(value, bb.IsLittleEndian);
            bb.Put(ba, 0, ba.Length, bbindex);
        }
        public static UInt32 GetUInt32(ByteBuffer bb, int bbindex)
        {
            byte[] batmp = new byte[4];
            bb.Get(batmp, 0, 4, bbindex);
            return ToUInt32(batmp, bb.IsLittleEndian);
        }
        #endregion
        #region long
        public static void PutLong(ByteBuffer bb, int bbindex, long value)
        {
            byte[] ba = GetBytes(value, bb.IsLittleEndian);
            bb.Put(ba, 0, ba.Length, bbindex);
        }
        public static long GetLong(ByteBuffer bb, int bbindex)
        {
            byte[] batmp = new byte[8];
            bb.Get(batmp, 0, 8, bbindex);
            return ToLong(batmp, bb.IsLittleEndian);
        }

        #endregion

        #region float
        /// <summary>
        /// 写浮点数，单精度32位，在指定位置
        /// </summary>
        /// <param name="bb">ByteBuffer</param>
        /// <param name="bbindex">ByteBuffer中要写入的起始地址</param>
        /// <param name="value">要写入的值</param>
        public static void PutFloat(ByteBuffer bb, int bbindex, float value)
        {
            byte[] ba = GetBytes(value, bb.IsLittleEndian);
            bb.Put(ba, 0, ba.Length, bbindex);
        }
        /// <summary>
        /// 读浮点数，单精度32位
        /// </summary>
        /// <param name="bb">ByteBuffer</param>
        /// <param name="bbindex">ByteBuffer中要读取的起始地址</param>
        /// <returns></returns>
        public static float GetFloat(ByteBuffer bb, int bbindex)
        {
            byte[] batmp = new byte[4];
            bb.Get(batmp, 0, 4, bbindex);
            return ToFloat(batmp, bb.IsLittleEndian);
        }

        #endregion
        #region double
        /// <summary>
        /// 写浮点数，双精度64位
        /// </summary>
        /// <param name="bb">ByteBuffer</param>
        /// <param name="bbindex">ByteBuffer中要写入的起始地址</param>
        /// <param name="value">要写入的值</param>
        public static void PutDouble(ByteBuffer bb, int bbindex, double value)
        {
            byte[] ba = GetBytes(value, bb.IsLittleEndian);
            bb.Put(ba, 0, ba.Length, bbindex);
        }
        /// <summary>
        /// 读浮点数，双精度64位
        /// </summary>
        /// <param name="bb">ByteBuffer</param>
        /// <param name="bbindex">ByteBuffer中要读取的起始地址</param>
        /// <returns></returns>
        public static double GetDouble(ByteBuffer bb, int bbindex)
        {
            byte[] batmp = new byte[8];
            bb.Get(batmp, 0, 8, bbindex);
            return ToDouble(batmp, bb.IsLittleEndian);
        }
        #endregion


        #region string

        public void PutString(ByteBuffer buf, string str, int stringMaxLength, int resultLength)
        {
            if (str.Length >= stringMaxLength)
            {
                str = str.Substring(0, stringMaxLength - 2);
            }
            int length = str.Length;
            if (resultLength == 0)
            {
                resultLength = length * 2 + 2;
            }
            byte[] tmp = new byte[resultLength];
            try
            {
                if (length != 0)
                {
                    byte[] cs = Encoding.Unicode.GetBytes(str);
                    Array.Copy(cs, tmp, cs.Length);
                    buf.Put(tmp, 0, resultLength);
                }

            }
            catch (Exception)
            {
                // May not occurs, UTF-16LE is a JDK mandatory implementation
            }
        }
        #endregion
    }
}
