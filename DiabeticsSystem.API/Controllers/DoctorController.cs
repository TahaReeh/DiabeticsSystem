using DiabeticsSystem.Application.Features.Doctors.Commands.CreateDoctor;
using DiabeticsSystem.Application.Features.Doctors.Commands.DeleteDoctor;
using DiabeticsSystem.Application.Features.Doctors.Commands.UpdateDoctor;
using DiabeticsSystem.Application.Features.Doctors.Queries.GetDoctorDetails;
using DiabeticsSystem.Application.Features.Doctors.Queries.GetDoctorList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DiabeticsSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllDoctors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<DoctorListVM>>> GetAllDoctors()
        {
            var dtos = await _mediator.Send(new GetDoctorListQuery());
            return Ok(dtos);
        }

        [HttpGet("GetDoctor")]
        public async Task<ActionResult<DoctorDetailsVM>> GetDoctor(Guid id)
        {
            var getDoctorDetailQuery = new GetDoctorDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getDoctorDetailQuery));
        }

        [HttpPost("CreateDoctor")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDoctorCommand createDoctorCommand)
        {
            var id = await _mediator.Send(createDoctorCommand);
            return Ok(id);
        }

        [HttpPut("UpdateDoctor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateDoctorCommand updateDoctorCommand)
        {
            await _mediator.Send(updateDoctorCommand);
            return NoContent();
        }

        [HttpDelete("DeleteDoctor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteDoctorCommand = new DeleteDoctorCommand() { Id = id };
            await _mediator.Send(deleteDoctorCommand);
            return NoContent();
        }
    }
}
