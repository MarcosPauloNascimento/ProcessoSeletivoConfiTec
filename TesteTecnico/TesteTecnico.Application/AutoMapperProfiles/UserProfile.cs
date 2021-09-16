using AutoMapper;
using TesteTecnico.Application.Dtos;
using TesteTecnico.Entities.Entities;

namespace Financial.AccountsReceiving.Api.Configuration.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.SchoolingId, opt => opt.MapFrom(src => src.Schooling.GetHashCode()))
                .ReverseMap();

        }
    }
}
