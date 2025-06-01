using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOrderAPI.Application.Products.DTOs
{
    public class GetProductResponse
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

    }
}
