using System;
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
            var request = new BookTableRequest(){NumberOfPersons = 0, DateTime = TestDates.Apr01, Duration = TimeSpan.FromMinutes(60)};

            // Act
            var result = _testClass.IsValidRequest(request);
            
            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsValidRequest_for_date_in_the_past_should_return_false()
        {
            // Arrange
            var request = new BookTableRequest(){NumberOfPersons = 1, DateTime = TestDates.Jan01, Duration = TimeSpan.FromMinutes(60)};

            // Act
            var result = _testClass.IsValidRequest(request);
            
            // Assert
            result.Should().BeFalse();
        }
        
        [Test]
        public void IsValidRequest_for_Duration_less_30_minutes_should_return_false()
        {
            // Arrange
            var request = new BookTableRequest(){NumberOfPersons = 1, DateTime = TestDates.Apr01, Duration = TimeSpan.FromMinutes(15)};

            // Act
            var result = _testClass.IsValidRequest(request);
            
            // Assert
            result.Should().BeFalse();
        }
        
        [Test]
        public void IsValidRequest_for_two_persons_in_future_for_60_mins_should_return_true()
        {
            // Arrange
            var request = new BookTableRequest(){NumberOfPersons = 2, DateTime = TestDates.Apr01, Duration = TimeSpan.FromMinutes(60)};

            // Act
            var result = _testClass.IsValidRequest(request);
            
            // Assert
            result.Should().BeTrue();
        }
    }
}