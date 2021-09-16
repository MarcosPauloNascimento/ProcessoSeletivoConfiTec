using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.Application.Dtos;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Entities.Entities;
using TesteTecnico.Entities.Entities.Enums;

namespace TesteTecnico.Application
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IMapper _mapper;
        private readonly IServiceUser _serviceUser;
        private readonly INotifier _notifier;

        public ApplicationServiceUser(IMapper mapper, IServiceUser serviceUser, INotifier notifier)
        {
            _mapper = mapper;
            _serviceUser = serviceUser;
            _notifier = notifier;
        }

        public async Task<int?> Add(UserDto userDto)
        {
            try
            {
                User user = _mapper.Map<UserDto, User>(userDto);
                await _serviceUser.Save(user);
                return user.Id;
            }
            catch (Exception e)
            {
                _notifier.AddNotification($"Erro ao tentar adicionar o usuário | {e.InnerException.Message}");
                return null;
            }
        }

        public async Task Update(UserDto userDto)
        {
            try
            {
                //var user = _serviceUser.Get(userDto.Id);

                var user = _mapper.Map<User>(userDto);
                await _serviceUser.Save(user);

            }
            catch (Exception e)
            {
                _notifier.AddNotification(e.Message);
            }
        }

        public async Task Delete(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                await _serviceUser.Delete(user);
            }
            catch (Exception e)
            {
                _notifier.AddNotification(e.Message);
            }
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
