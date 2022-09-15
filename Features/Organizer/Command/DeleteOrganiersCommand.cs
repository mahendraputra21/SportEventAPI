using SportEventAPI.Models;
using SportEventAPI.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SportEventAPI.Features.Organizer.Command
{
    public class DeleteOrganiersCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public class DeleteOrganiersCommandHandler : IRequestHandler<DeleteOrganiersCommand, Response>
        {

            private readonly IOrganizerService _organizerService;

            public DeleteOrganiersCommandHandler(IOrganizerService organizerService)
            {
                _organizerService = organizerService;
            }

            public async Task<Response> Handle(DeleteOrganiersCommand request, CancellationToken cancellationToken)
            {
                return await _organizerService.DeleteAsync(request.Token, request.Id);
            }
        }
    }
}
