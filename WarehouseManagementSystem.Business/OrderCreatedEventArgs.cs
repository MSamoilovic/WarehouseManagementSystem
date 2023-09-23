using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class OrderCreatedEventArgs: EventArgs
    {
        public Order? Order { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
    }
}
