using System.Threading.Tasks;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task Save(User user);
    }
}
