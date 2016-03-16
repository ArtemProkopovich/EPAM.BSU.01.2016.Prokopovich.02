using System;
using NUnit.Framework;
using Task4;

namespace Task4_NUnitTest
{
    [TestFixture]
    public class CustomerFormatProvider_Test
    {
        [Test]
        [TestCase("{0:N,P,R:C2}")]
        [TestCase("{0:N,R:F2,P}")]
        public void Customer_ToStringExtensionTestMethod(string format)
        {
            Customer customer = new Customer() { Name = "Jeff", Phone = "+375(29)000-00-00", Revenue = 10000.53m };
            string result = String.Format(new CustomerFormatProvider(), format, customer);
            Assert.AreNotEqual(result, string.Empty);
        }

        [Test, ExpectedException(typeof (FormatException))]
        [TestCase("{0:N,P,R:C23}")]
        [TestCase("{0:N,T:D2,P}")]
        [TestCase("{0:123}")]
        public void Customer_ToStringExtension_Exception_TestMethod(string format)
        {
            Customer customer = new Customer() {Name = "Jeff", Phone = "+375(29)000-00-00", Revenue = 10000.53m};
            string result = String.Format(new CustomerFormatProvider(), format, customer);
            Assert.AreNotEqual(result, string.Empty);
        }
    }
}