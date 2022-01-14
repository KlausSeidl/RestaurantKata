using FluentAssertions;
using NUnit.Framework;
using RestaurantService;

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
        public void BookTable_with_no_free_table_should_return_NoFreeTable()
        {
            // Arrange
            // --
            
            // Act
            var result = _testClass.BookTable();
            
            // Assert
            result.Status.Should().Be(BookTableStatus.NoFreeTable);
        }
    }
}