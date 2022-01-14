using RestaurantService.Platform;
using RestaurantService.Services;
using RestaurantService.Services.Mail;

namespace RestaurantService.Api
{
    public class ReservationService
    {
        private readonly IEmailService _emailService;
        private readonly ITableReservationService _tableReservationService;

        public ReservationService(
            ITableReservationService tableReservationService,
            IEmailService emailService)
        {
            _tableReservationService = tableReservationService;
            _emailService = emailService;
        }

        public BookTableResponse BookTable(BookTableRequest request)
        {
            if (!_tableReservationService.IsValidRequest(request))
            {
                return new BookTableResponse { Status = BookTableStatus.InvalidRequest };
            }
            
            if (!_tableReservationService.HasFreeTable(request))
            {
                return new BookTableResponse { Status = BookTableStatus.NoFreeTable };
            }

            _tableReservationService.StoreReservation();
            _emailService.Send(new Message { To = Session.CurrentUser.Email });

            return new BookTableResponse { Status = BookTableStatus.Success };
        }
    }
}