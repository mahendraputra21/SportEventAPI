using SportEventAPI.Models;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SportEventAPI.Domain;

namespace SportEventAPI.Services
{
    public class LoginCommand : IRequest<Response>
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, Response>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;

            public LoginCommandHandler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<Response> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                    return new ResponseFailed("Email cannot empty!");

                if (string.IsNullOrWhiteSpace(request.Password))
                    return new ResponseFailed("Email cannot empty!");

                return await _userService.LoginAsync(_mapper.Map<UserDto>(request));
            }
        }

    }


}
