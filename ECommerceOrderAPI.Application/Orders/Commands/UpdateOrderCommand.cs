using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceOrderAPI.Application.Orders.DTOs;
using MediatR;

namespace ECommerceOrderAPI.Application.Orders.Commands
{
    public class UpdateOrderCommand:IRequest<Unit>
    {
        public UpdateOrderCommand(long id, ICollection<UpdateOrderDTO> dtos) {
            Id = id;
            DTOs = dtos;
        }
        public long Id { get; set; }
        public ICollection<UpdateOrderDTO> DTOs { get; set; }
    }
}
