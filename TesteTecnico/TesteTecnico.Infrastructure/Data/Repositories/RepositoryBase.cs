using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.Domain.Interfaces.Repositories;

namespace TesteTecnico.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext _sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _sqlContext.AddAsync<TEntity>(entity);
            await _sqlContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _sqlContext.Update<TEntity>(entity);
            await _sqlContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _sqlContext.Remove<TEntity>(entity);
            await _sqlContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(int entityId)
        {
            return await _sqlContext.FindAsync<TEntity>(entityId);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _sqlContext.FindAsync<List<TEntity>>();
        }
        
    }
}
