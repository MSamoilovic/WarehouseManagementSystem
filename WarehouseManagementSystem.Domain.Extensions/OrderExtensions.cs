using System.Text;

namespace WarehouseManagementSystem.Domain.Extensions
{
    public static class OrderExtensions
    {
        public static string GenerateReport(this Order order)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"ORDER REPORT {order.OrderNumber}");
            builder.AppendLine($"Items: {order.LineItems?.Count()}");
            builder.AppendLine($"Total: {order.Total}");
            
            return builder.ToString();
        }

        public static string GenerateReport(this Order order, string receipient)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"ORDER REPORT ({order.OrderNumber})");
            builder.AppendLine($"Items: {order.LineItems?.Count()}");
            builder.AppendLine($"Total: {order.Total}");
            builder.AppendLine($"Send to: {receipient}");

            return builder.ToString();
        }
    }
}
