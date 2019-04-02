using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetByteBuffer.Unit
{
    [TestClass]
    public class UnitTest_ByteBuffer
    {
        void dispba(byte[] bs, string bsname)
        {
            Console.WriteLine(bsname + ":" + BitConverter.ToString(bs));
        }
        void dispbb(DotNetByteBuffer.ByteBuffer bb, string bbname)
        {
            Console.WriteLine(bbname + ":" + bb);
        }

        [TestMethod]
        public void TestMethod1()
        {
            DotNetByteBuffer.ByteBuffer bb = new ByteBuffer();


            Console.WriteLine(); Console.WriteLine("byte---------");

            byte[] ba = { 1, 2, 3, 4 };
            dispba(ba, "ba");
            bb.Put(ba[0]);
            bb.Put(ba[1]);
            bb.Put(ba[2]);
            bb.Flip();
            dispbb(bb, "bb");
            ba = new byte[] { 0, 0, 0, 0 };
            bb.Get(ba, 0, 3);
            dispba(ba, "ba");

            Console.WriteLine(); Console.WriteLine("byte[]---------");

            ba = new byte[] { 1, 2, 3, 4 };
            bb.Clear();
            bb.Put(ba, 0, ba.Length);
            bb.Flip();
            Console.WriteLine(bb);
            ba = new byte[] { 0, 0, 0, 1 };
            bb.Get(ba, 0, 3);
            dispba(ba, "ba");

            Console.WriteLine(); Console.WriteLine("int---------");

            int intv = 0x01020304;
            Console.WriteLine("{0:x4}", intv);

            Console.WriteLine();

            Console.WriteLine("LittleEndian");
            bb.Clear();
            bb.PutInt(intv);
            bb.Flip();
            dispbb(bb, "bb");
            intv = bb.GetInt();
            Console.WriteLine("{0:x4}", intv);

            Console.WriteLine();

            Console.WriteLine("BigEndian");
            bb.Clear();
            bb.IsLittleEndian = false;
            bb.PutInt(intv);
            bb.Flip();
            dispbb(bb, "bb");
            intv = bb.GetInt();
            Console.WriteLine("{0:x4}", intv);

            Console.WriteLine(); Console.WriteLine("short---------");

            short shortv = 0x0102;
            Console.WriteLine("{0:x4}", shortv);

            Console.WriteLine("LittleEndian");
            bb.Clear();
            bb.IsLittleEndian = true;
            bb.PutShort(shortv);
            bb.Flip();
            dispbb(bb, "bb");
            shortv = bb.GetShort();
            Console.WriteLine("{0:x4}", shortv);

            Console.WriteLine();

            Console.WriteLine("BigEndian");
            bb.Clear();
            bb.IsLittleEndian = false;
            bb.PutShort(shortv);
            bb.Flip();
            dispbb(bb, "bb");
            shortv = bb.GetShort();
            Console.WriteLine("{0:x4}", shortv);

            Console.WriteLine(); Console.WriteLine("long---------");

            long longv = 0x0102030405060708;
            Console.WriteLine("{0:x4}", longv);

            Console.WriteLine("LittleEndian");
            bb.Clear();
            bb.IsLittleEndian = true;
            bb.PutLong(longv);
            bb.Flip();
            dispbb(bb, "bb");
            longv = bb.GetLong();
            Console.WriteLine("{0:x4}", longv);

            Console.WriteLine();

            Console.WriteLine("BigEndian");
            bb.Clear();
            bb.IsLittleEndian = false;
            bb.PutLong(longv);
            bb.Flip();
            dispbb(bb, "bb");
            longv = bb.GetLong();
            Console.WriteLine("{0:x4}", longv);

        }


        [TestMethod]
        public void TestMethod_Float()
        {
            DotNetByteBuffer.ByteBuffer bb = new ByteBuffer();

            Console.WriteLine(); Console.WriteLine("float---------");

            float floatv = 1.234567890123456789f;
            Console.WriteLine("{0}", floatv);

            Console.WriteLine("LittleEndian");
            bb.Clear();
            bb.IsLittleEndian = true;
            bb.PutFloat(floatv);
            bb.Flip();
            dispbb(bb, "bb");
            floatv = bb.GetFloat();
            Console.WriteLine("{0}", floatv);

            Console.WriteLine();

            Console.WriteLine("BigEndian");
            bb.Clear();
            bb.IsLittleEndian = false;
            bb.PutFloat(floatv);
            bb.Flip();
            dispbb(bb, "bb");
            floatv = bb.GetFloat();
            Console.WriteLine("{0}", floatv);
        }
        [TestMethod]
        public void TestMethod_Double()
        {
            DotNetByteBuffer.ByteBuffer bb = new ByteBuffer();

            Console.WriteLine(); Console.WriteLine("double---------");

            double doublev = 1.234567890123456789d;
            Console.WriteLine("{0}", doublev);

            Console.WriteLine("LittleEndian");
            bb.Clear();
            bb.IsLittleEndian = true;
            bb.PutDouble(doublev);
            bb.Flip();
            dispbb(bb, "bb");
            doublev = bb.GetDouble();
            Console.WriteLine("{0}", doublev);

            Console.WriteLine();

            Console.WriteLine("BigEndian");
            bb.Clear();
            bb.IsLittleEndian = false;
            bb.PutDouble(doublev);
            bb.Flip();
            dispbb(bb, "bb");
            doublev = bb.GetDouble();
            Console.WriteLine("{0}", doublev);
        }

        [TestMethod]
        public void TestMethod_UInt32()
        {
            DotNetByteBuffer.ByteBuffer bb = new ByteBuffer();

            Console.WriteLine(); Console.WriteLine("UInt32---------");

            UInt32 UInt32v = 0x01020304;
            Console.WriteLine("{0:x4}", UInt32v);

            Console.WriteLine("LittleEndian");
            bb.Clear();
            bb.IsLittleEndian = true;
            bb.PutUInt32(UInt32v);
            bb.Flip();
            dispbb(bb, "bb");
            UInt32v = bb.GetUInt32();
            Console.WriteLine("{0:x4}", UInt32v);

            Console.WriteLine();

            Console.WriteLine("BigEndian");
            bb.Clear();
            bb.IsLittleEndian = false;
            bb.PutUInt32(UInt32v);
            bb.Flip();
            dispbb(bb, "bb");
            UInt32v = bb.GetUInt32();
            Console.WriteLine("{0:x4}", UInt32v);
        }

        [TestMethod]
        public void TestMethod_Set()
        {
            DotNetByteBuffer.ByteBuffer bb = new ByteBuffer();

            Console.WriteLine(); Console.WriteLine("Set---------");

            byte[] ba = { 1, 2, 3, 4 };

            bb.Put(ba);
            bb.Flip();
            dispbb(bb, "bb");

            bb.Clear();
            bb.Put(ba, 0, 3);
            bb.Flip();
            dispbb(bb, "bb");
        }
    }
}