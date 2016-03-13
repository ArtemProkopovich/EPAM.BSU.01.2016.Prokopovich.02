using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace NewtonRootMSTestLibrary
{
    [TestClass]
    public class RootUnitTest
    {
        [TestMethod]
        public void Root_WithNumber_4_Power_2_Return_2()
        {
            double result = Newton.Root(4.0, 2);
            Assert.IsTrue(Math.Abs(result - Math.Pow(4.0, 1.0/2)) < 0.000001);
        }

        [TestMethod]
        public void Root_WithNumber_Neg9_Power_3_Return_Neg3()
        {
            double result = Newton.Root(-9.0, 3);
            Assert.IsTrue(Math.Abs(result - -Math.Pow(9.0, 1.0/3)) < 0.000001);
        }

        [TestMethod]
        public void Root_WithNumber_0_Power_3_Return_0()
        {
            double result = Newton.Root(0, 3);
            Assert.IsTrue(Math.Abs(result - Math.Pow(0, 1.0 / 3)) < 0.000001);
        }

        [TestMethod]
        public void Root_WithNumber_10_Power_1_Return_10()
        {
            double result = Newton.Root(10, 1);
            Assert.IsTrue(Math.Abs(result - Math.Pow(10, 1.0)) < 0.000001);
        }

        [TestMethod]
        public void Root_WithNumberLessAccuracy_Power_10_ReturnEqualsMath()
        {
            double result = Newton.Root(0.0000001, 10);
            Assert.IsTrue(Math.Abs(result - Math.Pow(0.0000001, 1.0/10)) < 0.000001);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Root_WithPower_0_ReturnException()
        {
            Newton.Root(5, 0);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Root_WithNegNumber_Power_2_ReturnException()
        {
            Newton.Root(-5, 2);
        }

        [TestMethod, ExpectedException(typeof(OverflowException))]
        public void Root_WithNumber_100_Power_10000_ReturnException()
        {
            Newton.Root(100, 10000);
        }
    }
}
