using System;
using RestaurantService.Services;

namespace RestaurantService.Api
{
    public class ReservationService
    {
        private ITableReservationService _tableReservationService;

        public ReservationService(ITableReservationService tableReservationService)
        {
            _tableReservationService = tableReservationService;
        }

        public BookTableResponse BookTable(BookTableRequest request)
        {
            if (!_tableReservationService.HasFreeTable(request))
            {
                return new BookTableResponse { Status = BookTableStatus.NoFreeTable };
            }

            return new BookTableResponse { Status = BookTableStatus.Success };
        }
    }
}