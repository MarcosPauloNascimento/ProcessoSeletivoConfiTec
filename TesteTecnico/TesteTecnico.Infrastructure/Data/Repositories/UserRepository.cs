using TesteTecnico.Entities.Entities;
using TesteTecnico.Domain.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace TesteTecnico.Infrastructure.Data.Repositories
{
    public class UserRepository : RepositoryBase<Usuario>, IUserRepository
    {
        private readonly SqlContext _sqlContext;

        public UserRepository(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
