using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Domain.Core.Interfaces.Services
{
    public interface IServiceUser : IDisposable
    {
        Task Add(Usuario user);
        Task Update(Usuario user);

        Task Delete(Usuario user);

        Task<Usuario> Get(int id);

        Task<IEnumerable<Usuario>> GetAll();

        void Detach(Usuario user);
    }
}
