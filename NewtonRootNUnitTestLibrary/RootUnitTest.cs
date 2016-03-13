using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using NUnit.Framework;

namespace NewtonRootNUnitTestLibrary
{
    [TestFixture]
    public class RootUnitTest
    {
        [Test]
        [TestCase(4.0, 2)]
        [TestCase(0, 3)]
        [TestCase(10, 1)]
        [TestCase(0.00000001, 10)]
        public void Root_CorrectEvulationTest(double num, int pow)
        {
            Assert.IsTrue(Math.Abs(Newton.Root(num, pow) - Math.Pow(num, 1.0/pow)) < 0.000001);
        }

        [Test]
        [TestCase(-9, 3)]
        public void Root_NegNumber_OddPower_Test(double num, int pow)
        {
            Assert.IsTrue(Math.Abs(Newton.Root(num, pow) - -Math.Pow(-num, 1.0 / pow)) < 0.000001);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        [TestCase(5, 0)]
        [TestCase(-5, 2)]
        public void Root_ArgumentExceptionTest(double num, int pow)
        {
            Newton.Root(num, pow);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void Root_ArgumentExceptionTest()
        {
            Newton.Root(10, 2, 0);
        }

        [Test, ExpectedException(typeof(OverflowException))]
        public void Root_OverflowExceptionTest()
        {
            Newton.Root(100, 100000);
        }
    }
}
