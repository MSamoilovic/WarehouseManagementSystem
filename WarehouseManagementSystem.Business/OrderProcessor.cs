using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
    public class OrderProcessor
    {
        public Func<Order, bool>? OnOrderInitialized { get; set; }

        public event EventHandler<OrderCreatedEventArgs>? OrderCreated;
        public event EventHandler<OrderCompletedEventArgs>? OrderCompleted;
        private void Initialize(Order order)
        {
        }

        protected virtual void OnOrderCreated(OrderCreatedEventArgs args)
        {
            OrderCreated?.Invoke(this, args);
        }

        protected virtual void OnOrderCompleted(OrderCompletedEventArgs args)
        {
            OrderCompleted?.Invoke(this, args);
        }

        public void Process(Order order)
        {
            // Run some code..
            ArgumentNullException.ThrowIfNull(order);

            if (OnOrderInitialized?.Invoke(order) == false)
            {
                throw new InvalidOperationException($"Nesto je poslo po zlu po order {order.OrderNumber}");
            };

            Initialize(order);

            OnOrderCreated(new()
            {
                Order = order,
                OldPrice = 250,
                NewPrice = 240
            });

            //OnOrderFinalized?.Invoke(order);

            OnOrderCompleted(new() { Order = order });

            // How do I produce a shipping label?
        }

        public string Process(Order order, decimal discount)
        {
            return string.Empty;
        }

        
    }
} 