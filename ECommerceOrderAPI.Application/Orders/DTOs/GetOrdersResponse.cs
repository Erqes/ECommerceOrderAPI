using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOrderAPI.Application.Orders.DTOs
{
    public class GetOrdersResponse
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double? TotalPrice { get; set; }
    }
}
