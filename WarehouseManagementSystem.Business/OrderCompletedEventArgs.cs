using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class OrderCompletedEventArgs: EventArgs
    {
        public Order? Order { get; set; }
    }
}
