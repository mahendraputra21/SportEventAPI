using SportEventAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SportEventAPI.Models;
using NLog;
using MediatR;
using SportEventAPI.Features.Organizer.Query;
using SportEventAPI.Features.Organizer.Command;
using System;
using SportEventAPI.Domain;

namespace SportEventAPI.Controllers
{
    [Route("api/v1/oraganizers")]
    [ApiController]
    public class organizerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public organizerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// getAllOrganizers
        /// </summary>
        /// <param name="page"></param>
        /// <param name="perPage"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(int page, int perPage)
        {
            try
            {
                var authorization = Request.Headers[HeaderNames.Authorization];
                if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
                {
                    var getOrganizersQuery = new GetOrganizersQuery()
                    {
                        Page = page,
                        PerPage = perPage,
                        Token = headerValue.Parameter,
                    };

                    return Ok(await _mediator.Send(getOrganizersQuery));
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
        /// getOrganizer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var authorization = Request.Headers[HeaderNames.Authorization];
                if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
                {

                    return Ok(await _mediator.Send(new GetOrganizersQuery() { Id = id, Token = headerValue.Parameter }));
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
        /// createOrganizer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrganizersCommand request)
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
        /// updateOrganizer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] OrganizersCommand request)
        {
            try
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
                    return Ok("Unautorized!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// deleteOrganizer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var authorization = Request.Headers[HeaderNames.Authorization];
                if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
                {
                    var delOrganizerCommand = new DeleteOrganiersCommand()
                    {
                        Id = id,
                        Token = headerValue.Parameter,
                    };

                    return Ok(await _mediator.Send(delOrganizerCommand));
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
    }
}
