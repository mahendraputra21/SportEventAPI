using SportEventAPI.Models;
using SportEventAPI.Services;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SportEventAPI.Domain;

namespace SportEventAPI.Features.Organizer.Command
{
    public class OrganizersCommand : IRequest<Response>
    {
        public int Id { get; set; } = 0;
        [JsonProperty("organizerName")]
        public string OrganizerName { get; set; }
        [JsonProperty("imageLocation")]
        public string ImageLocation { get; set; }
        public string Token { get; set; }

        public class CreateOrganizersCommandHandler : IRequestHandler<OrganizersCommand, Response>
        {
            private readonly IOrganizerService _organizerService;
            private readonly IMapper _mapper;

            public CreateOrganizersCommandHandler(IOrganizerService organizerService, IMapper mapper)
            {
                _organizerService = organizerService;
                _mapper = mapper;
            }

            public async Task<Response> Handle(OrganizersCommand request, CancellationToken cancellationToken)
            {

                var organizer = _mapper.Map<OrganizerDto>(request);
 
                if (request.Id > 0)
                    return await _organizerService.PutAsync(request.Token, request.Id, organizer);

                return await _organizerService.PostAsync(request.Token, organizer);
            }
        }

    }
}

