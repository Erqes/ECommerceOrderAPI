using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceOrderAPI.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public DeleteProductCommand(long id) => Id = id;

        public long Id { get; set; }
    }
}
