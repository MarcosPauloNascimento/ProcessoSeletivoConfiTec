using AutoMapper;
using TesteTecnico.Application.Dtos;
using TesteTecnico.Entities.Entities;
using TesteTecnico.Entities.Entities.Enums;

namespace Financial.AccountsReceiving.Api.Configuration.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.SchoolingId, opt => opt.MapFrom(src => src.Schooling.GetHashCode()));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Schooling, opt => opt.MapFrom(src => (Schooling)src.SchoolingId));

        }
    }
}
