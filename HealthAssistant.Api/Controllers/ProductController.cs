using HealthAssistant.Application.UseCases.Products.Commands.CreateProduct;
using HealthAssistant.Application.UseCases.Products.Commands.UpdateProduct;
using HealthAssistant.Application.UseCases.Products.Queries.GetAllProducts;
using HealthAssistant.Application.UseCases.Products.Queries.GetByName;
using HealthAssistant.Application.UseCases.Products.Queries.SearchListProductsByName;
using HealthAssistant.Application.UseCAses.Products.Commands.DeleteProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthAssistant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Создать продукт
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command, CancellationToken token)
        {
            var product = await _mediator.Send(command, token);
            return Ok(product);
        }

        /// <summary>
        /// Удалить продукт
        /// </summary>
        /// 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommand command, CancellationToken token)
        {
            await _mediator.Send(command, token);
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command, CancellationToken token)
        {
            await _mediator.Send(command, token);
            return Ok();
        }

        [HttpGet("query/{name}")]

        public async Task<IActionResult> GetProductByName([FromRoute] GetProductByNameQuery query, CancellationToken token)
        {
            var product = await _mediator.Send(query, token);
            return Ok(product);
        }

        /// <summary>
        /// Получить все продукты
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken token)
        {

            var products = await _mediator.Send(new GetAllProductsQuery(), token);

            return Ok(products);
        }

        [HttpGet("{query}")]

        public async Task<IActionResult> SearchListProductsByName([FromRoute] SearchListProductsByNameQuery query, CancellationToken token)
        {
            var products = await _mediator.Send(query, token);
            return Ok(products);
        }


    }
}
