using RestaurantService.Api;

namespace RestaurantService.Services
{
    public interface ITableReservationService
    {
        bool HasFreeTable(BookTableRequest request);
        void StoreReservation();
    }

    public class TableReservationService : ITableReservationService
    {
        public bool HasFreeTable(BookTableRequest request)
        {
            throw new System.NotImplementedException();
        }

        public void StoreReservation()
        {
            throw new System.NotImplementedException();
        }
    }
}