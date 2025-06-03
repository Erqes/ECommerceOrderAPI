using ECommerceOrderAPI.Application.Orders.Commands;
using ECommerceOrderAPI.Application.Orders.DTOs;
using ECommerceOrderAPI.Application.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceOrderAPI.UI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetOrder([FromRoute] long id)
        {
            var result = await mediator.Send(new GetOrderQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var result = await mediator.Send(new GetOrdersQuery());
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] long id)
        {
            await mediator.Send(new DeleteOrderCommand(id));
            return Ok();
        }
        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] long id, [FromBody] ICollection<UpdateOrderDTO> dtos)
        {
            await mediator.Send(new UpdateOrderCommand(id, dtos));
            return Ok();
        }
    }
}
