using System;
using RestaurantService.Services;
using RestaurantService.Services.Mail;

namespace RestaurantService.Api
{
    public class ReservationService
    {
        private ITableReservationService _tableReservationService;
        private IEmailService _emailService;
        
        public ReservationService(
            ITableReservationService tableReservationService, 
            IEmailService emailService)
        {
            _tableReservationService = tableReservationService;
            _emailService = emailService;
        }

        public BookTableResponse BookTable(BookTableRequest request)
        {
            if (!_tableReservationService.HasFreeTable(request))
            {
                return new BookTableResponse { Status = BookTableStatus.NoFreeTable };
            }

            _tableReservationService.StoreReservation();
            _emailService.Send(new Message());
            
            return new BookTableResponse { Status = BookTableStatus.Success };
        }
    }
}