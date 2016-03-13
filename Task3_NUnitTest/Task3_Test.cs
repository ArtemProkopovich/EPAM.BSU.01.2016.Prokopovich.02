using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task3;

namespace Task3_NUnitTest
{
    [TestFixture]
    public class Task3_Test
    {
        [Test, TestCase(64, Result = "40")]
        [TestCase(100, Result = "64")]
        [TestCase(-100, Result = "-64")]
        [TestCase(0, Result = "0")]
        [TestCase(25485, Result = "638D")]
        [TestCase(88979905, Result = "54DB9C1")]
        public string IntExtension_Test(int number)
        {
            return number.HexFormat();
        }
    }
}
