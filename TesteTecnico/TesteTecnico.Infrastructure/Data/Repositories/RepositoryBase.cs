using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.Domain.Core.Interfaces.Repositories;

namespace TesteTecnico.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly SqlContext _sqlContext;
        protected readonly DbSet<TEntity> _dbSet;
        private bool disposed = false;

        protected RepositoryBase(SqlContext db)
        {
            _sqlContext = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _sqlContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _sqlContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _sqlContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _sqlContext?.Dispose();
                }

                disposed = true;
            }
        }

    }
}
