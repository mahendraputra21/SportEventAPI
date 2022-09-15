using SportEventAPI.Features.SportEvents.Query.Model;
using SportEventAPI.Features.SportEvents.Services;
using SportEventAPI.Models;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace SportEventAPI.Features.SportEvents.Command
{
    public class SportEventCommand : IRequest<Response>
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("eventDate")]
        public string EventDate { get; set; }

        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("organizerId")]
        public int OrganizerId { get; set; }
        public string Token { get; set; }

        public class SportEventCommandHandler : IRequestHandler<SportEventCommand, Response>
        {
            private readonly ISportEventService _sportEventService;
            private readonly IMapper _mapper;

            public SportEventCommandHandler(ISportEventService sportEventService, IMapper mapper)
            {
                _sportEventService = sportEventService;
                _mapper = mapper;
            }

            public async Task<Response> Handle(SportEventCommand request, CancellationToken cancellationToken)
            {
                var sportEvent = _mapper.Map<CreateSportEventRequest>(request);

                if (request.Id > 0)
                    return await _sportEventService.PutAsync(request.Token, request.Id, sportEvent);

                return await _sportEventService.PostAsync(request.Token, sportEvent);
            }
        }
    }
}
