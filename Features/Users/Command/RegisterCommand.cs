using SportEventAPI.Models;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SportEventAPI.Domain;

namespace SportEventAPI.Services
{
    public class RegisterCommand : IRequest<Response>
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("repeatPassword")]
        public string RepeatPassword { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;

            public RegisterCommandHandler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<Response> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                if(string.IsNullOrWhiteSpace(request.Email))
                    return new ResponseFailed("Email cannot empty!");

                if(string.IsNullOrWhiteSpace(request.Password))
                    return new ResponseFailed("Email cannot empty!");

                return await _userService.CreateUserAsync(_mapper.Map<UserDto>(request));
            }
        }
    }


}
