using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOrderAPI.Application.Orders.DTOs
{
    public class UpdateOrderDTO
    {

        public long ProductId { get; set; }
        public int Quantity { get; set; }


    }
}
