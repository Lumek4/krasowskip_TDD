using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            var res = TDD.Program.Parse("");
            Assert.AreEqual(res, 0);
        }
        [TestMethod]
        public void Test2()
        {
            var res = TDD.Program.Parse("123");
            Assert.AreEqual(res, 123);
            res = TDD.Program.Parse("13");
            Assert.AreEqual(res, 13);
            res = TDD.Program.Parse("12");
            Assert.AreEqual(res, 12);
        }
        [TestMethod]
        public void Test3()
        {
            var res = TDD.Program.Parse("123,1");
            Assert.AreEqual(res, 124);
            res = TDD.Program.Parse("13,12");
            Assert.AreEqual(res, 25);
            res = TDD.Program.Parse("0,1");
            Assert.AreEqual(res, 1);
        }
        [TestMethod]
        public void Test4()
        {
            var res = TDD.Program.Parse("123\n1");
            Assert.AreEqual(res, 124);
            res = TDD.Program.Parse("13\n12");
            Assert.AreEqual(res, 25);
            res = TDD.Program.Parse("0\n1");
            Assert.AreEqual(res, 1);
        }
        [TestMethod]
        public void Test5()
        {
            var res = TDD.Program.Parse("123\n0\n1");
            Assert.AreEqual(res, 124);
            res = TDD.Program.Parse("13\n12\n100");
            Assert.AreEqual(res, 125);
            res = TDD.Program.Parse("0,1,100");
            Assert.AreEqual(res, 101);
        }
        [TestMethod]
        public void Test6()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var res = TDD.Program.Parse("120\n0\n-1\n3");
                }
                catch (Exception)
                {
                    continue;
                }
                Assert.Fail();
            }
        }
        [TestMethod]
        public void Test7()
        {
            var res = TDD.Program.Parse("123\n0\n1\n1002");
            Assert.AreEqual(res, 124);
            res = TDD.Program.Parse("13\n2000\n12\n100");
            Assert.AreEqual(res, 125);
            res = TDD.Program.Parse("1302,0,1,100");
            Assert.AreEqual(res, 101);
        }
        [TestMethod]
        public void Test8()
        {
            var res = TDD.Program.Parse("//#\n123#0#1");
            Assert.AreEqual(res, 124);
            res = TDD.Program.Parse("//#\n13#12#100");
            Assert.AreEqual(res, 125);
            res = TDD.Program.Parse("//$\n0$1$100");
            Assert.AreEqual(res, 101);
        }
        [TestMethod]
        public void Test9()
        {
            var res = TDD.Program.Parse("//[&&]\n123&&0&&1");
            Assert.AreEqual(res, 124);
            res = TDD.Program.Parse("//[#@!]\n13#@!12#@!100");
            Assert.AreEqual(res, 125);
            res = TDD.Program.Parse("//[$$$]\n0$$$1$$$100");
            Assert.AreEqual(res, 101);
        }
    }
}
