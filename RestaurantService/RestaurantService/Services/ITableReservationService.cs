using RestaurantService.Api;

namespace RestaurantService.Services
{
    public interface ITableReservationService
    {
        bool HasFreeTable(BookTableRequest request);
    }
}