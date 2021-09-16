using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Domain.Core.Interfaces.Services
{
    public interface IServiceUser : IDisposable
    {
        Task Save(User user);

        Task Delete(User user);

        Task<User> Get(int id);

        Task<IEnumerable<User>> GetAll();

        void Detach(User user);
    }
}
