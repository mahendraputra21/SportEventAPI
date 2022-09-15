using SportEventAPI.Features.SportEvents.Services;
using SportEventAPI.Models;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SportEventAPI.Features.SportEvents.Command
{
    public class DeleteSportEventCommand : IRequest<Response>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public string Token { get; set; }

        public class DeleteSportEventCommandHandler : IRequestHandler<DeleteSportEventCommand, Response>
        {
            private readonly ISportEventService _sportEventService;

            public DeleteSportEventCommandHandler(ISportEventService sportEventService)
            {
                _sportEventService = sportEventService;
            }

            public async Task<Response> Handle(DeleteSportEventCommand request, CancellationToken cancellationToken)
            {
                return await _sportEventService.DeleteAsync(request.Token, request.Id);
            }
        }
    }
}
