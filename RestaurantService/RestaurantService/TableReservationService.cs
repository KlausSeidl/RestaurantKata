namespace RestaurantService
{
    public class TableReservationService
    {
        public BookTableResponse BookTable()
        {
            return new BookTableResponse() { Status = BookTableStatus.NoFreeTable };
        }
    }

    public enum BookTableStatus
    {
        Success,
        NoFreeTable
    }
    
    public class BookTableResponse
    {
        public BookTableStatus Status { get; set; }    
    }
}