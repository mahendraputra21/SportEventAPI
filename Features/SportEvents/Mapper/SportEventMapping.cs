using AutoMapper;
using SportEventAPI.Features.SportEvents.Command;
using SportEventAPI.Features.SportEvents.Query.Model;

namespace SportEventAPI.Features.SportEvents.Mapper
{
    public class SportEventMapping : Profile
    {
        public SportEventMapping()
        {
            CreateMap<SportEventCommand, CreateSportEventRequest>();
        }
    }
}
