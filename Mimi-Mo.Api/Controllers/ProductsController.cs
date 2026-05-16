using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Application.Features.Products.Commands.CreateProduct;
using Mimo_Mo.Application.Features.Products.Commands.DeleteProduct;
using Mimo_Mo.Application.Features.Products.Commands.UpdateProduct;
using Mimo_Mo.Application.Features.Products.Queries.GetAllProducts;
using Mimo_Mo.Application.Features.Products.Queries.GetProductById;

namespace Mimi_Mo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
       
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var dtoWithUser = dto with { UserId = userId }; 
            var result = await _mediator.Send(new CreateProductCommand(dtoWithUser));
            return Ok(result);
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }
        
        
        [Authorize(Roles = "Admin")]
        [HttpPatch]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            var result = await _mediator.Send(new UpdateProductCommand(dto));
            return Ok(result);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(result);
        }
    }
}