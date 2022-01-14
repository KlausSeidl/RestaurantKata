using System;
using RestaurantService.Services;

namespace RestaurantServiceTests
{
    public class TestDates
    {
        public static readonly DateTime Jan01 = new DateTime(2022, 1, 1);
        public static readonly DateTime Feb01 = new DateTime(2022, 2, 1);
        public static readonly DateTime Mar01 = new DateTime(2022, 3, 1);
        public static readonly DateTime Apr01 = new DateTime(2022, 4, 1);
    }
    
    public class DateTimeServiceMock : IDateTimeService
    {
        private DateTime _now;
        
        public DateTime Now => _now;

        public void SetNow(DateTime now)
        {
            _now = now;
        }
    }
}