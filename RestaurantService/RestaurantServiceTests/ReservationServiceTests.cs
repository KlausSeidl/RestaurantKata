using System;
using FluentAssertions;
using NUnit.Framework;
using RestaurantService.ReservationService;

namespace RestaurantServiceTests
{
    [TestFixture]
    public class ReservationServiceTests
    {
        [SetUp]
        public void Setup()
        {
            _testClass = new ReservationService();
        }

        private ReservationService _testClass;

        [Test]
        public void BookTable_with_no_free_table_should_return_NoFreeTable()
        {
            // Arrange
            var request = new BookTableRequest { UserId = Guid.Empty };

            // Act
            var result = _testClass.BookTable(request);

            // Assert
            result.Status.Should().Be(BookTableStatus.NoFreeTable);
        }

        [Test]
        public void BookTable_with_free_table_should_return_Success()
        {
            // Arrange
            var request = new BookTableRequest { UserId = Guid.NewGuid() };

            // Act
            var result = _testClass.BookTable(request);

            // Assert
            result.Status.Should().Be(BookTableStatus.Success);
        }
    }
}