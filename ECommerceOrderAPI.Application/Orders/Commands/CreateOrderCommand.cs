using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Orders.DTOs;
using MediatR;

namespace ECommerceOrderAPI.Application.Orders.Commands
{
    public class CreateOrderCommand:IRequest<Unit>
    {
        public ICollection<CreateOrderDTO> OrderItems { get; set; }
    }
}
