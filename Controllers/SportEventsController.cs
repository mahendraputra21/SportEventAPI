using SportEventAPI.Features.SportEvents.Command;
using SportEventAPI.Features.SportEvents.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;

namespace SportEventAPI.Controllers
{

    [Route("api/v1/sport-events")]
    [ApiController]
    public class SportEventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SportEventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// getAllSportEvents
        /// </summary>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <param name="organizerId"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "sport-event" })]
        public async Task<IActionResult> Get(int page, int perPage, int organizerId)
        {
            try
            {
                var authorization = Request.Headers[HeaderNames.Authorization];
                if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
                {
                    var getSportQuery = new GetSportEventQuery()
                    {
                        Page = page,
                        PerPage = perPage,
                        Token = headerValue.Parameter,
                        OrganizerId = organizerId,
                    };

                    return Ok(await _mediator.Send(getSportQuery));
                }
                else
                {
                    return Ok("Unautorized!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// getSportEvent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Tags = new[] { "sport-event" })]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var authorization = Request.Headers[HeaderNames.Authorization];
                if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
                {
                    var getSportByIdQuery = new GetSportEventQuery()
                    {
                        Id = id,
                        Token = headerValue.Parameter,
                    };

                    return Ok(await _mediator.Send(getSportByIdQuery));
                }
                else
                {
                    return Ok("Unautorized!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        /// <summary>
        /// createSportEvent
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Tags = new[] { "sport-event" })]
        public async Task<IActionResult> Post([FromBody] SportEventCommand request)
        {
            try
            {
                var authorization = Request.Headers[HeaderNames.Authorization];
                if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
                {
                    request.Token = headerValue.Parameter;
                    return Ok(await _mediator.Send(request));
                }
                else
                {
                    return Ok("Unautorized!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// updateSportEvent
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Tags = new[] { "sport-event" })]
        public async Task<IActionResult> Put(int id, [FromBody] SportEventCommand request)
        {
            var authorization = Request.Headers[HeaderNames.Authorization];
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                request.Id = id;
                request.Token = headerValue.Parameter;
                return Ok(await _mediator.Send(request));
            }
            else
            {
                return Ok("Unautorized");
            }
        }

        /// <summary>
        /// deleteSportEvent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Tags = new[] { "sport-event" })]
        public async Task<IActionResult> Delete(int id)
        {
            var authorization = Request.Headers[HeaderNames.Authorization];
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var deleteSportEvent = new DeleteSportEventCommand()
                {
                    Id = id,
                    Token = headerValue.Parameter,
                };

                return Ok(await _mediator.Send(deleteSportEvent));
            }
            else
            {
                return Ok("Unautorized");
            }
        }
    }
}
