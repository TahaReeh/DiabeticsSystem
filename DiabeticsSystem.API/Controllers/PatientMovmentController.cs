using DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerList;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DiabeticsSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientMovmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientMovmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllPatientMovments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PatientMovmentListVM>>> GetAllPatientMovments()
        {
            var dtos = await _mediator.Send(new GetPatientMovmentListQuery());
            return Ok(dtos);
        }
    }
}
