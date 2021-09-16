using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.Application.Dtos;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Application
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IMapper _mapper;
        private readonly IServiceUser _serviceUser;

        public ApplicationServiceUser(IMapper mapper, IServiceUser serviceUser)
        {
            _mapper = mapper;
            _serviceUser = serviceUser;
        }

        public async Task Save(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _serviceUser.Save(user);
        }

        public async Task Delete(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _serviceUser.Delete(user);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var user = await _serviceUser.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(user);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _serviceUser.Get(id);
            return _mapper.Map<UserDto>(user);
        }

        
    }
}
