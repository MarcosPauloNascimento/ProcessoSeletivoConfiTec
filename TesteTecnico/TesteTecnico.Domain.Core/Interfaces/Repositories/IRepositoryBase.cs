using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteTecnico.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {

        Task AddAsync(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<TEntity> GetAsync(int entityId);
        Task<List<TEntity>> GetAllAsync();
    }
}
