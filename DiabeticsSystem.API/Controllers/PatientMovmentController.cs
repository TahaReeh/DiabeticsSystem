using AspNetCore.Reporting;
using DiabeticsSystem.API.Utility;
using DiabeticsSystem.Application.Features.PatientMovements.Commands.CreatePatientMovement;
using DiabeticsSystem.Application.Features.PatientMovements.Commands.DeletePatientMovement;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentByCustomer;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DiabeticsSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientMovmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PatientMovmentController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
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

        [HttpGet("ExportPatientMovmentsToCSV")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportAllPatientMovments()
        {
            var fileDto = await _mediator.Send(new GetPatientMovementExportQuery() { ExportType = 1 });

            return File(fileDto.Data!, fileDto.ContentType, fileDto.PatientMovementExportFileName);
        }

        [HttpGet("ExportAllPatientMovmentsToPDF")]
        [FileResultContentType("application/pdf")]
        public async Task<FileResult> ExportAllPatientMovmentsToPDF()
        {
            var fileDto = await _mediator.Send(new GetPatientMovementExportQuery()
            {
                ExportType = 2,
                Path = $"{_webHostEnvironment.WebRootPath}\\Reports\\PatientMovmentsReport.rdlc"
            });

            return File(fileDto.Data!, fileDto.ContentType, fileDto.PatientMovementExportFileName);
        }
    }
}
