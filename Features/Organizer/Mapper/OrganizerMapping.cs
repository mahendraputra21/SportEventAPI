using AutoMapper;
using SportEventAPI.Domain;
using SportEventAPI.Features.Organizer.Command;

namespace SportEventAPI.Features.Organizer.Mapper
{
    public class OrganizerMapping : Profile
    {
        public OrganizerMapping()
        {
            CreateMap<OrganizersCommand, OrganizerDto>();
        }
    }
}
