using SportEventAPI.Features.Users.Query.Model;
using SportEventAPI.Models;
using SportEventAPI.Services;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SportEventAPI.Domain;

namespace SportEventAPI.Features.Users.Query
{
    public class GetUserByIdQuery : IRequest<Response>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public string Token { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;

            public GetUserByIdQueryHandler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<Response> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                return await _userService.GetByIdAsync(_mapper.Map<UserDto>(request), request.Token);
            }
        }
    }
}
