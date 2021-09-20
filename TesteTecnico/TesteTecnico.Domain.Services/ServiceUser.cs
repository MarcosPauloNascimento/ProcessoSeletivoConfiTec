using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.Domain.Core.Interfaces.Repositories;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Domain.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IUserRepository _userRepository;

        public ServiceUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Add(Usuario user)
        {
            await _userRepository.Add(user);
        }

        public async Task Update(Usuario user)
        {
            await _userRepository.Update(user);
        }

        public async Task Delete(Usuario user)
        {
            await _userRepository.Delete(user);
        }

        public async Task<Usuario> Get(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public void Detach(Usuario user)
        {
            _userRepository.Detach(x => x.Id == user.Id);
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
