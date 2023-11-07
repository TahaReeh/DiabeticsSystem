using DiabeticsSystem.API.Utility;
using DiabeticsSystem.Application.Features.PatientMovements.Commands.CreatePatientMovement;
using DiabeticsSystem.Application.Features.PatientMovements.Commands.DeletePatientMovement;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentByCustomer;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport;
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

        [HttpGet("GetAllPatientsMovments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PatientMovmentListVM>>> GetAllPatientMovments()
        {
            var dtos = await _mediator.Send(new GetPatientMovmentListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetPatientMovmentByCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PatientMovmentByCustomerVM>>> GetPatientMovmentByCustomer(Guid customerId)
        {
            var dtos = await _mediator.Send(new GetPatientMovmentByCustomerQuery() { CustomerId = customerId });
            return Ok(dtos);
        }

        [HttpPost("CreatePatientMovment")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePatientMovementCommand createPatientMovmentCommand)
        {
            var id = await _mediator.Send(createPatientMovmentCommand);
            return Ok(id);
        }

        [HttpDelete("DeletePatientMovment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePatientMovementCommand = new DeletePatientMovementCommand() { PatientMovementId = id };
            await _mediator.Send(deletePatientMovementCommand);
            return NoContent();
        }

        [HttpGet("ExportAllPatientMovments")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportAllPatientMovments()
        {
            var fileDto = await _mediator.Send(new GetPatientMovementExportQuery());

            return File(fileDto.Data!, fileDto.ContentType, fileDto.PatientMovementExportFileName);
        }
    }
}
