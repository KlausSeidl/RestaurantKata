using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RestaurantService.Api;
using RestaurantService.Platform;
using RestaurantService.Services;
using RestaurantService.Services.Mail;

namespace RestaurantServiceTests
{
    [TestFixture]
    public class ReservationServiceTests
    {
        [SetUp]
        public void Setup()
        {
            _tableReservationService = new Mock<ITableReservationService>();
            _emailService = new Mock<IEmailService>();

            Session.CurrentUser = new User { Email = "kseidl@recom.eu" };

            _testClass = new ReservationService(_tableReservationService.Object, _emailService.Object);
        }

        private Mock<ITableReservationService> _tableReservationService;
        private Mock<IEmailService> _emailService;

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
        public void BookTable_with_free_table_should_Store_reservation()
        {
            // Arrange
            var request = new BookTableRequest();
            _tableReservationService.Setup(x => x.HasFreeTable(It.IsAny<BookTableRequest>())).Returns(true);

            // Act
            _testClass.BookTable(request);

            // Assert
            _tableReservationService.Verify(x => x.StoreReservation(), Times.Once);
        }

        [Test]
        public void BookTable_with_free_table_should_send_confirmation_mail()
        {
            // Arrange
            var request = new BookTableRequest();
            _tableReservationService.Setup(x => x.HasFreeTable(It.IsAny<BookTableRequest>())).Returns(true);

            // Act
            _testClass.BookTable(request);

            // Assert
            _emailService.Verify(x => x.Send(It.IsAny<Message>()), Times.Once);
        }

        [Test]
        public void BookTable_with_free_table_should_send_confirmation_mail_to_correct_recipient()
        {
            // Arrange
            var request = new BookTableRequest();
            _tableReservationService.Setup(x => x.HasFreeTable(It.IsAny<BookTableRequest>())).Returns(true);

            // Act
            _testClass.BookTable(request);

            // Assert
            _emailService.Verify(
                x => x.Send(It.Is(new Message { To = "kseidl@recom.eu" }, EqualityComparer<Message>.Default)),
                Times.Once);
        }
    }
}