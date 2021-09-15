using TesteTecnico.Entities.Entities;
using TesteTecnico.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace TesteTecnico.Infrastructure.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly SqlContext _sqlContext;

        public UserRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task Save(User user)
        {
            if (user.Id == 0)
                await AddAsync(user);
            else
                await Update(user);
        }
    }
}
