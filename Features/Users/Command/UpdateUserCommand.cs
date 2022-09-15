using SportEventAPI.Features.Users.Query.Model;
using SportEventAPI.Models;
using SportEventAPI.Services;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SportEventAPI.Domain;

namespace SportEventAPI.Features.Users.Command
{
    public class UpdateUserCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Token { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;

            public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<Response> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                return await _userService.PutAsync(_mapper.Map<UserDto>(request), request.Id, request.Token);
            }
        }
    }
}
