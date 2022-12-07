using ArtTableWeb.Application.Features.Commands.About.CreateAbout;
using ArtTableWeb.Application.Features.Commands.About.DeleteAbout;
using ArtTableWeb.Application.Features.Commands.About.UpdateAbout;
using ArtTableWeb.Application.Features.Queries.About.GetAbout;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ArtTableWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAboutQueryRequest getAboutQueryRequest) 
        {
            List<GetAboutQueryResponse> response = await _mediator.Send(getAboutQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromQuery] CreateAboutCommandRequest createAboutCommandRequest)
        {
            CreateAboutCommandResponse response = await _mediator.Send(createAboutCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteAboutCommandRequest deleteAboutCommandRequest)
        {
            DeleteAboutCommandResponse response = await _mediator.Send(deleteAboutCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromQuery]UpdateAboutCommandRequest updateAboutCommandRequest)
        {
            UpdateAboutCommandResponse response = await _mediator.Send(updateAboutCommandRequest);
            return Ok(response);
        }
    }
}
