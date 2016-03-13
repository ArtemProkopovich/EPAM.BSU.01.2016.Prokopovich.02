using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2_NUnitTest
{
    [TestFixture]
    public class GCDEuclidTest
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(54, 90).Returns(18);
                yield return new TestCaseData(90, 54).Returns(18);
                yield return new TestCaseData(10, 1).Returns(1);
                yield return new TestCaseData(1, 10).Returns(1);
                yield return new TestCaseData(10, 0).Returns(10);
                yield return new TestCaseData(0, 0).Returns(0);
                yield return new TestCaseData(17, 6).Returns(1);
                yield return new TestCaseData(20, 20).Returns(20);
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public int GCDEuclidEvulationTest(int num1,int num2)
        {
            return Gcd.Euclid(num1, num2);
        }

        [Test, TestCase(10240, 1000, 60,Result = 20)]
        public int GCDEuclidEvulationTest(int num1, int num2, int num3)
        {
            return Gcd.Euclid(num1, num2, num3);
        }

        [Test, TestCase(10240, 1000, 60, 10, Result = 10)]
        public int GCDEuclidEvulationTest(params int[] array)
        {
            return Gcd.Euclid(array);
        }

        [Test]
        public void GCD10_10Return10_Time_Not0()
        {
            TimeSpan time;
            Gcd.Euclid(10, 10, out time);
            Assert.AreNotEqual(time.Ticks, 0);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        [TestCase(100)]
        public void GCDWithOneParam_ThrowException(int num)
        {
            Gcd.Euclid(num);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        [TestCase(100,-100)]
        [TestCase(-100,100)]
        public void GCDWithLessThanZero_Param(int num1, int num2)
        {
            Gcd.Euclid(num1, num2);
        }
    }
}
