using System;
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
            var request = new BookTableRequest() { UserId = Guid.Empty };
            
            // Act
            var result = _testClass.BookTable(request);
            
            // Assert
            result.Status.Should().Be(BookTableStatus.NoFreeTable);
        }
        
        [Test]
        public void BookTable_with_free_table_should_return_Success()
        {
            // Arrange
            var request = new BookTableRequest() { UserId = Guid.NewGuid() };
            
            // Act
            var result = _testClass.BookTable(request);
            
            // Assert
            result.Status.Should().Be(BookTableStatus.Success);
        }
    }
}