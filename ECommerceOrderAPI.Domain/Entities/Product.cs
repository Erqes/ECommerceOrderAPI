using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOrderAPI.Domain.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
