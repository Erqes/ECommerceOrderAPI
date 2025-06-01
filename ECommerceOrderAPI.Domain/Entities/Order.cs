using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOrderAPI.Domain.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double? TotalPrice { get; set; }

        public ICollection<ProductOrder> ProductOrders;
    }
}
