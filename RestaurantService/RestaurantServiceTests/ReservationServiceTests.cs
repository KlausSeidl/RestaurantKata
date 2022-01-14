using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RestaurantService.Api;
using RestaurantService.Services;

namespace RestaurantServiceTests
{
    [TestFixture]
    public class ReservationServiceTests
    {
        private Mock<ITableReservationService> _tableReservationService;
        
        [SetUp]
        public void Setup()
        {
            _tableReservationService = new Mock<ITableReservationService>();
            
            _testClass = new ReservationService(_tableReservationService.Object);
        }

        private ReservationService _testClass;

        [Test]
        public void BookTable_with_no_free_table_should_return_NoFreeTable()
        {
            // Arrange
            var request = new BookTableRequest();
            _tableReservationService.Setup(x => x.HasFreeTable(It.IsAny<BookTableRequest>())).Returns(false);

            // Act
            var result = _testClass.BookTable(request);

            // Assert
            result.Status.Should().Be(BookTableStatus.NoFreeTable);
        }

        [Test]
        public void BookTable_with_free_table_should_return_Success()
        {
            // Arrange
            var request = new BookTableRequest();
            _tableReservationService.Setup(x => x.HasFreeTable(It.IsAny<BookTableRequest>())).Returns(true);

            // Act
            var result = _testClass.BookTable(request);

            // Assert
            result.Status.Should().Be(BookTableStatus.Success);
        }
        
        [Test]
        public void BookTable_with_free_table_should_return_Store_reservation()
        {
            // Arrange
            var request = new BookTableRequest();
            _tableReservationService.Setup(x => x.HasFreeTable(It.IsAny<BookTableRequest>())).Returns(true);

            // Act
            var result = _testClass.BookTable(request);

            // Assert
            _tableReservationService.Verify(x => x.StoreReservation(), Times.Once);
        }
    }
}