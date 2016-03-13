using System;
using NUnit.Framework;
using Task4;

namespace Task4_NUnitTest
{
    [TestFixture]
    public class Customer_ToFormatStringTest
    {
        [Test]
        [TestCase("N,P,R:C2")]
        [TestCase("N,R:F2,P")]
        public void Customer_ToStringExtensionTestMethod(string format)
        {
            Customer customer = new Customer() { Name = "Jeff", Phone = "+375(29)000-00-00", Revenue = 10000.53m };
            Assert.AreNotEqual(customer.ToFormatString(format), string.Empty);
        }

        [Test, ExpectedException(typeof (FormatException))]
        [TestCase("N,P,R:C23")]
        [TestCase("N,T:D2,P")]
        public void Customer_ToStringExtension_Exception_TestMethod(string format)
        {
            Customer customer = new Customer() {Name = "Jeff", Phone = "+375(29)000-00-00", Revenue = 10000.53m};
            customer.ToFormatString(format);
        }
    }
}