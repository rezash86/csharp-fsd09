using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BasicMathsTest
{
    //https://www.c-sharpcorner.com/article/a-basic-introduction-of-unit-test-for-beginners/
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_AddMethod()
        {
            BasicMaths.BasicMaths bm = new BasicMaths.BasicMaths();
            double res = bm.Add(10, 10);
            Assert.AreEqual(res, 20);
        }

        [TestMethod]
        public void Test_SubstractMethod()
        {
            BasicMaths.BasicMaths bm = new BasicMaths.BasicMaths();
            double res = bm.Substract(10, 10);
            Assert.AreEqual(res, 0);
        }
        [TestMethod]
        public void Test_DivideMethod()
        {
            BasicMaths.BasicMaths bm = new BasicMaths.BasicMaths();
            double res = bm.divide(10, 5);
            Assert.AreEqual(res, 2);
        }
        [TestMethod]
        public void Test_MultiplyMethod()
        {
            BasicMaths.BasicMaths bm = new BasicMaths.BasicMaths();
            double res = bm.Multiply(10, 10);
            Assert.AreEqual(res, 100);
        }
    }
}
