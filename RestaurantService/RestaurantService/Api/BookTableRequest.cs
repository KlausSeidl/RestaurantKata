using System;

namespace RestaurantService.Api
{
    public class BookTableRequest
    {
        public int NumberOfPersons { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}