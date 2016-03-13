using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Task2_MSTest
{
    [TestClass]
    public class GCDEuclidTest
    {
        [TestMethod]
        public void GCD54_90Return18()
        {
            Assert.AreEqual(Gcd.Euclid(54, 90), 18);
        }
        [TestMethod]
        public void GCD90_54Return_18()
        {
            Assert.AreEqual(Gcd.Euclid(90, 54), 18);
        }
        [TestMethod]
        public void GCD10_1Return_1()
        {
            Assert.AreEqual(Gcd.Euclid(10, 1), 1);
        }
        [TestMethod]
        public void GCD1_10Return_1()
        {
            Assert.AreEqual(Gcd.Euclid(1, 10), 1);
        }
        [TestMethod]
        public void GCD0_0Return0()
        {
            Assert.AreEqual(Gcd.Euclid(0, 0), 0);
        }
        [TestMethod]
        public void GCD10_0Return10()
        {
            Assert.AreEqual(Gcd.Euclid(10, 0), 10);
        }
        [TestMethod]
        public void GCD17_6Return1()
        {
            Assert.AreEqual(Gcd.Euclid(17, 6), 1);
        }
        [TestMethod]
        public void GCD20_20Return20()
        {
            Assert.AreEqual(Gcd.Euclid(20, 20), 20);
        }

        [TestMethod]
        public void GCD10240_1000_60Return_20()
        {
            Assert.AreEqual(Gcd.Euclid(10240, 1000, 60), 20);
        }
        [TestMethod]
        public void GCD10240_1000_60_10Return_10()
        {
            Assert.AreEqual(Gcd.Euclid(10240, 1000, 60, 10), 10);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void GCDWithOneParam_ThrowException()
        {
            Gcd.Euclid(102);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void GCDWithLessThanZero_FParam()
        {
            Gcd.Euclid(-102,100);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void GCDWithLessThanZero_SParam()
        {
            Gcd.Euclid(100, -100);
        }

        [TestMethod]
        public void GCD10_10Return10_Time_Not0()
        {
            TimeSpan time;
            Gcd.Euclid(10, 10, out time);
            Assert.AreNotEqual(time.Ticks, 0);
        }
    }
}
