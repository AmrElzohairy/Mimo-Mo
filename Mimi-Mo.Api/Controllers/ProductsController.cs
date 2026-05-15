using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Application.Features.Products.Commands.CreateProduct;
using Mimo_Mo.Application.Features.Products.Commands.UpdateProduct;
using Mimo_Mo.Application.Features.Products.Queries.GetAllProducts;

namespace Mimi_Mo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
       
            var result = await _mediator.Send(new CreateProductCommand(dto));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            var result = await _mediator.Send(new UpdateProductCommand(dto));
            return Ok(result);
        }
    }
}