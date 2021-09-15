using System.Threading.Tasks;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Domain.Core.Interfaces.Repositories
{
    interface IUserRepository : IRepositoryBase<User>
    {
        Task Save(User user);
    }
}
