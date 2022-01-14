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
        public void HasFreeTable_for_zero_persons()
        {
            // Arrange
            var request = new BookTableRequest();

            // Act
            var result = _testClass.HasFreeTable(request);
            
            // Assert
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