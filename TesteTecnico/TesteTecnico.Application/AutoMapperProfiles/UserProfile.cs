using AutoMapper;
using System;
using TesteTecnico.Application.Dtos;
using TesteTecnico.Entities.Entities;
using TesteTecnico.Entities.Entities.Enums;

namespace Financial.AccountsReceiving.Api.Configuration.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(dest => dest.EscolaridadeId, opt => opt.MapFrom(src => GetHashCode(src.Escolaridade)));

            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.Escolaridade, opt => opt.MapFrom(src => (Schooling)src.EscolaridadeId));

        }

        private int GetHashCode(string escolaridade)
        {
            return Enum.Parse<Schooling>(escolaridade).GetHashCode();
        }
    }
}
