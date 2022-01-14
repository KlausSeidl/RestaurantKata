using RestaurantService.Api;

namespace RestaurantService.Services
{
    public interface ITableReservationService
    {
        bool IsValidRequest(BookTableRequest request);
        bool HasFreeTable(BookTableRequest request);
        void StoreReservation();
    }

    public class TableReservationService : ITableReservationService
    {
        public bool IsValidRequest(BookTableRequest request)
        {
            return false;
        }

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