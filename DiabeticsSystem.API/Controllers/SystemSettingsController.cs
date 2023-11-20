using DiabeticsSystem.Application.Features.Products.Commands.UpdateProduct;
using DiabeticsSystem.Application.Features.SystemSettings.Commands;
using DiabeticsSystem.Application.Features.SystemSettings.Queries.GetSystemSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DiabeticsSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemSettingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SystemSettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetUserSystemSettings")]
        public async Task<ActionResult> GetUserSystemSettings(string userId)
        {
            var dto = await _mediator.Send(new GetSystemSettingsQuery() { UserId = userId });
            return Ok(dto);
        }

        [HttpPut("UpdateUserSystemSettings")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateSystemSettingsCommand updateSystemSettings)
        {
            await _mediator.Send(updateSystemSettings);
            return NoContent();
        }
    }
}
