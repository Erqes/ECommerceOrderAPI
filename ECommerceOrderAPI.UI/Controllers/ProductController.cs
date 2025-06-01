
using ECommerceOrderAPI.Application.Products.Commands;
using ECommerceOrderAPI.Application.Products.DTOs;
using ECommerceOrderAPI.Application.Products.Queries;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceOrderAPI.UI.Controllers
{
    [Route("Product")]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetProduct([FromRoute] long id)
        {
            var result = await mediator.Send(new GetProductQuery(id));
            return Ok(result);
        }
        [HttpGet]
        [Route("productsAll")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await mediator.Send(new GetProductsQuery());
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            await mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }
        [HttpPut]
        [Route("{id:long}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] UpdateProductDTO dto)
        { 
            await mediator.Send(new UpdateProductCommand(id, dto));
            return Ok();
        }
    }
}
