using NUnit.Framework;
using RestaurantService.Services.Mail;

namespace RestaurantServiceTests
{
    [TestFixture]
    public class MailAddressTests
    {
        [TestCase("kseidl@recom.eu", "kseidl@recom.eu", ExpectedResult = true)]
        [TestCase("kseidl@recom.eu", " kseidl@recom.eu", ExpectedResult = false)]
        [TestCase("kseidl@recom.eu", "rreustle@recom.eu", ExpectedResult = false)]
        public bool Equality_operator(string left, string right)
        {
            // Arrange
            var address1 = new MailAddress(left);
            var address2 = new MailAddress(right);
            
            // Act
            return address1 == address2;
        }
        
        [TestCase("kseidl@recom.eu", "kseidl@recom.eu", ExpectedResult = false)]
        [TestCase("kseidl@recom.eu", " kseidl@recom.eu", ExpectedResult = true)]
        [TestCase("kseidl@recom.eu", "rreustle@recom.eu", ExpectedResult = true)]
        public bool Inequality_operator(string left, string right)
        {
            // Arrange
            var address1 = new MailAddress(left);
            var address2 = new MailAddress(right);
            
            // Act
            return address1 != address2;
        }
        
        [TestCase("kseidl@recom.eu", "kseidl@recom.eu", ExpectedResult = true)]
        [TestCase("kseidl@recom.eu", " kseidl@recom.eu", ExpectedResult = false)]
        [TestCase("kseidl@recom.eu", "rreustle@recom.eu", ExpectedResult = false)]
        public bool Equals_method(string left, string right)
        {
            // Arrange
            var address1 = new MailAddress(left);
            var address2 = new MailAddress(right);
            
            // Act
            return address1.Equals(address2);
        }
    }
}