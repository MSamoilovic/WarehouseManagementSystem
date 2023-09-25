using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;

var order = new Order
{
    LineItems = new[]
    {
        new Item {Name = "PS1", Price = 23},
        new Item {Name = "PS2", Price = 23},
        new Item {Name = "PS3", Price = 23},
        new Item {Name = "PS4", Price = 23},
        new Item {Name = "PS5", Price = 23}
    }
};

var processor = new OrderProcessor();

//Extension methods

var report = order.GenerateReport("Marko Samoilovic");
Console.WriteLine(report);

foreach (var item in order.LineItems.Find(item => item.Price > 10))
{
    Console.WriteLine(item.Name);
} 

processor.OnOrderInitialized = SendToWarehouse;


//Poziv preko lambde Action<T>
var chain = (Order order) => Console.WriteLine($"Reduce stock quantity for order no.{order.OrderNumber}");
chain += (order) => Console.WriteLine($"Confirmation email for order {order.OrderNumber} sent.");

//Event Handling
processor.OrderCreated += (sender, args) =>
{
    Console.WriteLine($"{args?.Order?.OrderNumber}");
    Console.WriteLine($"Reduce stock quantity for order no.{args?.Order?.OrderNumber}");
    Console.WriteLine($"Confirmation email for order {args?.Order?.OrderNumber} sent.");
};

processor.OrderCreated += Log;

processor.Process(order);

bool SendToWarehouse(Order order)
{
    Console.WriteLine($"Order no.{order.OrderNumber} is ready for packing.");

    return true;
}

void Log(object sender, OrderCreatedEventArgs args)
{
    Console.WriteLine("Log Method Call");
}

