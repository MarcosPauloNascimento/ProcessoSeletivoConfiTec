using AutoMapper;
using TesteTecnico.Application.Dtos;
using TesteTecnico.Entities.Entities;

namespace Financial.AccountsReceiving.Api.Configuration.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
