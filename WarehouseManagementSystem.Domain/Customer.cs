using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Domain
{
    public record Customer(string FirstName, string LastName)
    {
        public string FullName => $"{FirstName} {LastName}";
        public Address Address { get; init; }
    };

    public record Address(string street, string town);

    public record PriorityCustomer(string FirstName, string LastName): Customer(FirstName, LastName);
}
