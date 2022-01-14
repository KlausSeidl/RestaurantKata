using NUnit.Framework;

namespace RestaurantServiceTests
{
    [TestFixture]
    public class TableReservationServiceTests
    {
        private TableReservationService _testClass;
        
        public void Setup()
        {
            _testClass = new TableReservationService();
        }
    }
}