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

        public async Task Save(User user)
        {
            if (user.Id == 0)
                await _userRepository.Add(user);
            else
                await _userRepository.Update(user);
        }

        public async Task Delete(User user)
        {
            await _userRepository.Delete(user);
        }

        public async Task<User> Get(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public void Detach(User user)
        {
            _userRepository.Detach(x => x.Id == user.Id);
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }        
    }
}
