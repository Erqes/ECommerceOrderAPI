using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOrderAPI.Application.Orders.DTOs
{
    public class GetOrderResponse
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double? TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public class OrderItem
        {
            public long ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }
}
