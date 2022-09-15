using AutoMapper;
using SportEventAPI.Domain;
using SportEventAPI.Features.Users.Command;
using SportEventAPI.Features.Users.Query;
using SportEventAPI.Services;

namespace SportEventAPI.Features.Users.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<LoginCommand, UserDto>();
            CreateMap<RegisterCommand, UserDto>();
            CreateMap<GetUserByIdQuery, UserDto>();
            CreateMap<DeleteUserCommand, UserDto>();
            CreateMap<UpdateUserCommand, UserDto>();
        }
    }
}
