using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task3;
using System.Globalization;
using System.Threading;

namespace Task3_NUnitTest
{
    [TestFixture]
    public class Task3_Test
    {
        [Test, TestCase(64, Result = "0x40")]
        [TestCase(100, Result = "0x64")]
        [TestCase(-100, Result = "0x-64")]
        [TestCase(0, Result = "0x0")]
        [TestCase(25485, Result = "0x638D")]
        [TestCase(88979905, Result = "0x54DB9C1")]
        [TestCase(47.2, ExpectedException = typeof(ArgumentException))]
        public string IntExtension_Test(int number)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IFormatProvider fp = new IntHexFormatProvider();
            return string.Format(fp, "{0:H}", number);
        }

        [TestCase(47, "{0:X}", Result = "2F")]
        [TestCase(.473, "{0:P}", Result = "47.30 %")]
        [TestCase(.473, "{0:P0}", Result = "47 %")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.7321, "{0:F2}", Result = "4.73")]
        public string ParentFormat_Test(object number, string format)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IFormatProvider fp = new IntHexFormatProvider();
            return string.Format(fp, format, number);
        }
    }
}
