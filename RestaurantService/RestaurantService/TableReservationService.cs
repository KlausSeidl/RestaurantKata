using System;

namespace RestaurantService
{
    public class TableReservationService
    {
        public BookTableResponse BookTable(BookTableRequest request)
        {
            if (request.UserId == Guid.Empty)
            {
                return new BookTableResponse() { Status = BookTableStatus.NoFreeTable };
            }
            
            return new BookTableResponse() { Status = BookTableStatus.Success };
        }
    }
}