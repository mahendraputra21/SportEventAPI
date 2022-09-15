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
    public class DeleteUserCommand : IRequest<Response>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public string Token { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;

            public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<Response> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                return await _userService.DeleteAsync(_mapper.Map<UserDto>(request), request.Token);
            }
        }
    }
}
