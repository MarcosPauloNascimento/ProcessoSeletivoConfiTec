using TesteTecnico.Entities.Entities;
using TesteTecnico.Domain.Core.Interfaces.Repositories;
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
    }
}
