using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceOrderAPI.Application.Orders.Commands
{
    public class DeleteOrderCommand:IRequest<Unit>
    {
        public DeleteOrderCommand(long id)=>Id = id;
        

        public long Id { get; set; }
    }
}
