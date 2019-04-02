using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetByteBuffer
{
    public class ByteBufferUtility
    {
        public static String GetString(ByteBuffer bb)
        {
            int length = 0;
            for (; ; length += 2)
            {
                if (bb.Get() == 0 & bb.Get() == 0)
                {
                    break;
                }
            }
            byte[] tmp = new byte[length];
            try
            {

                char[] cs = Encoding.Unicode.GetChars(tmp, 0, length);
                return new string(cs);
            }
            catch (Exception)
            {

                return "";
            }

        }
        /// <summary>
        /// 从缓存中抽取字符串
        /// </summary>
        /// <param name="bb">要抽取缓存</param>
        /// <param name="nbrBytes">抽取的字节数</param>
        /// <returns></returns>
        public static String GetStringUnicode(ByteBuffer bb, int nbrBytes)
        {
            byte[] tmp = new byte[nbrBytes];
            byte[] data = bb.Data;

            bb.Get(tmp, 0, nbrBytes);

            int length = 0;
            for (; length < nbrBytes; length += 2)
            {
                if (tmp[length] == 0 && tmp[length + 1] == 0)
                {
                    break;
                }
            }

            char[] cs = Encoding.Unicode.GetChars(tmp, 0, length);
            return new string(cs);
        }
        public static String GetStringASCII(ByteBuffer bb, int nbrBytes)
        {
            byte[] tmp = new byte[nbrBytes];
            byte[] data = bb.Data;

            bb.Get(tmp, 0, nbrBytes);

            int length = 0;
            for (; length < nbrBytes; length += 2)
            {
                if (tmp[length] == 0 && tmp[length + 1] == 0)
                {
                    break;
                }
            }

            char[] cs = Encoding.ASCII.GetChars(tmp, 0, length);
            return new string(cs);
        }
        public static  void PutString(ByteBuffer bb, string str, int length)
        {

            byte[] bacoded = Encoding.Unicode.GetBytes(str);
            byte[] baresult = new byte[length];

            if (bacoded.Length > length - 2)
            {
                Array.Copy(bacoded, 0, baresult, 0, length - 2);
            }
            else
            {
                Array.Copy(bacoded, 0, baresult, 0, bacoded.Length);
            }

            bb.Put(baresult, 0, baresult.Length);
        }

    }
}
