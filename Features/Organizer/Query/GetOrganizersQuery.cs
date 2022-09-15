using SportEventAPI.Models;
using SportEventAPI.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SportEventAPI.Features.Organizer.Query
{
    public class GetOrganizersQuery : IRequest<Response>
    {
        public int Id { get; set; } = 0;
        public int Page { get; set; }
        public int PerPage { get; set; }
        public string Token { get; set; }

        public class GetOrganizersQueryHandler : IRequestHandler<GetOrganizersQuery, Response>
        {
            private readonly IOrganizerService _organizerService;

            public GetOrganizersQueryHandler(IOrganizerService organizerService)
            {
                _organizerService = organizerService;
            }

            public async Task<Response> Handle(GetOrganizersQuery request, CancellationToken cancellationToken)
            {
                if (request.Id > 0)
                    return await _organizerService.GetByIdAsync(request.Token, request.Id);

                return await _organizerService.GetAsync(request.Token, request.Page, request.PerPage);
            }
        }
    }
}
