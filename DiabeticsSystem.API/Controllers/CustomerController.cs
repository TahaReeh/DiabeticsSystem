using DiabeticsSystem.Application.Features.Customers.Commands.CreateCustomer;
using DiabeticsSystem.Application.Features.Customers.Commands.DeleteCustomer;
using DiabeticsSystem.Application.Features.Customers.Commands.UpdateCustomer;
using DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerDetails;
using DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DiabeticsSystem.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CustomerListVM>>> GetAllCustomers()
        {
            var dtos = await _mediator.Send(new GetCustomerListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetCustomer")]
        public async Task<ActionResult<CustomerDetailsVM>> GetCustomer(Guid id)
        {
            var getCustomerDetailQuery = new GetCustomerDetailsQuery() { Id = id};
            return Ok(await _mediator.Send(getCustomerDetailQuery));
        }

        [HttpPost("CreateCustomer")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var id = await _mediator.Send(createCustomerCommand);
            return Ok(id);
        }

        [HttpPut("UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            await _mediator.Send(updateCustomerCommand);
            return NoContent();
        }

        [HttpDelete("DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand() { Id = id };
            await _mediator.Send(deleteCustomerCommand);
            return NoContent();
        }
    }
}
