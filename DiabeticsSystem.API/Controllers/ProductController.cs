using DiabeticsSystem.Application.Features.Products.Commands.CreateProduct;
using DiabeticsSystem.Application.Features.Products.Commands.DeleteProduct;
using DiabeticsSystem.Application.Features.Products.Commands.UpdateProduct;
using DiabeticsSystem.Application.Features.Products.Queries.GetProductDetails;
using DiabeticsSystem.Application.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DiabeticsSystem.API.Controllers
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

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProductListVM>>> GetAllCustomers()
        {
            var dtos =await _mediator.Send(new GetProductListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetProduct")]
        public async Task<ActionResult<ProductDetailsVM>> GetProduct(Guid id)
        {
            var getProductDetailQuery = new GetProductDetailsQuery() { ProductId = id };
            return Ok(await _mediator.Send(getProductDetailQuery));
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var id = await _mediator.Send(createProductCommand);
            return Ok(id);
        }

        [HttpPut("UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return NoContent();
        }

        [HttpDelete("DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteProductCommand = new DeleteProductCommand() { ProductId = id };
            await _mediator.Send(deleteProductCommand);
            return NoContent();
        }
    }
}
