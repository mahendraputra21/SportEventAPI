using SportEventAPI.Features.SportEvents.Services;
using SportEventAPI.Models;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SportEventAPI.Features.SportEvents.Query
{
    public class GetSportEventQuery : IRequest<Response>
    {
        public int Id { get; set; } = 0;
        public int Page { get; set; }
        public int PerPage { get; set; }
        public string Token { get; set; }
        [JsonProperty("organizerId")]
        public int OrganizerId { get; set; }

        public class GetSportEventQueryHandler : IRequestHandler<GetSportEventQuery, Response>
        {
            private readonly ISportEventService _sportEventService;

            public GetSportEventQueryHandler(ISportEventService sportEventService)
            {
                _sportEventService = sportEventService;
            }

            public async Task<Response> Handle(GetSportEventQuery request, CancellationToken cancellationToken)
            {
                if (request.Id > 0)
                    return await _sportEventService.GetByIdAsync(request.Token, request.Id);

               return await _sportEventService.GetAsync(
                    request.Token, request.Page, request.PerPage, request.OrganizerId);
            }
        }
    }
}
