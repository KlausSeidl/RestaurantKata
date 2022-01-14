using System;

namespace RestaurantService.ReservationService
{
    public class ReservationService
    {
        public BookTableResponse BookTable(BookTableRequest request)
        {
            if (request.UserId == Guid.Empty) return new BookTableResponse { Status = BookTableStatus.NoFreeTable };

            return new BookTableResponse { Status = BookTableStatus.Success };
        }
    }
}