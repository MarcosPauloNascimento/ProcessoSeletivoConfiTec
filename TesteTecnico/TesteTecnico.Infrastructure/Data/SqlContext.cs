using Microsoft.EntityFrameworkCore;
using TesteTecnico.Entities.Entities;
using TesteTecnico.Infrastructure.Data.Configuration;

namespace TesteTecnico.Infrastructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

    }
}
