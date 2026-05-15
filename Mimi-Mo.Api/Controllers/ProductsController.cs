using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mimo_Mo.Application.Dtos.Product;
using Mimo_Mo.Application.Features.Products.Commands.CreateProduct;

namespace Mimi_Mo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
       
            var result = await _mediator.Send(new CreateProductCommand(dto));
            return Ok(result);
        }
    }
}