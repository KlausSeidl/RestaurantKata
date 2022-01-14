using FluentAssertions;
using NUnit.Framework;
using RestaurantService.Api;
using RestaurantService.Services;

namespace RestaurantServiceTests
{
    [TestFixture]
    public class TableReservationServiceTests
    {
        private TableReservationService _testClass;
        
        [SetUp]
        public void Setup()
        {
            _testClass = new TableReservationService();
        }

        [Test]
        public void IsValidRequest_for_zero_persons_should_return_false()
        {
            // Arrange
            var request = new BookTableRequest();

            // Act
            var result = _testClass.IsValidRequest(request);
            
            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void MethodName()
        {
            // Arrange
            
            // Act

            // Assert
        }
    }
}