using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Products.DTOs;
using MediatR;

namespace ECommerceOrderAPI.Application.Products.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public UpdateProductCommand(long id,UpdateProductDTO dto)
        {
            ProductName = dto.ProductName;
            Quantity = dto.Quantity;
            Price = dto.Price;
            Id = id;
        }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public long Id { get; set; }
    }
}
