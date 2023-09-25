using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Domain.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Find<T>(this IEnumerable<T> collection, Func<T, bool> isMatch)
        {
            foreach (var item in collection)
            {
                if (isMatch(item)) 
                {
                    yield return item;
                }
            }
        }
    }
}
