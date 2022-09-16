using SportEventAPI.Features.Users.Command;
using SportEventAPI.Features.Users.Query;
using SportEventAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;


namespace SportEventAPI.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class userController : ControllerBase
    {

        private readonly IMediator _mediator;

        public userController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// loginUser
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        /// <summary>
        /// createUser
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        /// <summary>
        /// getUser
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var authorization = Request.Headers[HeaderNames.Authorization];
                if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
                {
                    return Ok(await _mediator.Send(new GetUserByIdQuery() { Id = id, Token = headerValue.Parameter }));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }     
        }

        /// <summary>
        /// updateUser
        /// </summary>
        /// <param name="createUserRequest"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand createUserRequest, int id)
        {
            try
            {
                var authorization = Request.Headers[HeaderNames.Authorization];
                if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
                {
                    createUserRequest.Id = id;
                    createUserRequest.Token = headerValue.Parameter;

                    return Ok(await _mediator.Send(createUserRequest));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        /// <summary>
        /// deleteUser
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
                    return Ok(await _mediator.Send(new DeleteUserCommand() { Id = id, Token = headerValue.Parameter }));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
