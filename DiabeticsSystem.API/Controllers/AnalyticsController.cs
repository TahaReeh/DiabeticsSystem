using DiabeticsSystem.Application.Features.Analytics.Home;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DiabeticsSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalyticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetHomeAnalytics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<HomeAnalyticsVM>> GetHomeAnalytics()
        {
            var dtos = await _mediator.Send(new HomeAnalyticsQuery());
            return Ok(dtos);
        }
    }
}
