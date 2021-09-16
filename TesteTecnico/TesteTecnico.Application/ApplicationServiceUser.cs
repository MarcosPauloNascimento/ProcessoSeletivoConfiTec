using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.Application.Dtos;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Application.Validations;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Application
{
    public class ApplicationServiceUser : ServiceBase, IApplicationServiceUser
    {
        private readonly IMapper _mapper;
        private readonly IServiceUser _serviceUser;

        public ApplicationServiceUser(IMapper mapper, IServiceUser serviceUser, INotifier notifier)
            : base(notifier)
        {
            _mapper = mapper;
            _serviceUser = serviceUser;
        }

        public async Task<int?> Add(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<UserDto, User>(userDto);

                if(!ExecuteValidation(new UserValidations(), user))
                    return null;

                await _serviceUser.Save(user);
                return user.Id;
            }
            catch (Exception e)
            {
                Notify($"Erro ao tentar adicionar o usuário | {e.InnerException.Message}");
                return null;
            }
        }

        public async Task<bool> Update(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);

                if (!ExecuteValidation(new UserValidations(), user))
                    return false;

                await _serviceUser.Save(user);
                return true;
            }
            catch (Exception e)
            {
                Notify($"Erro ao tentar atualizar o usuário | {e.InnerException.Message}");
                return false;
            }
        }

        public async Task Delete(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                _serviceUser.Detach(user);
                await _serviceUser.Delete(user);
            }
            catch (Exception e)
            {
                Notify($"Erro ao tentar remover o usuário | {e.InnerException.Message}");
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
