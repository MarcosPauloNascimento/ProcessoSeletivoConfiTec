using Microsoft.EntityFrameworkCore;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
