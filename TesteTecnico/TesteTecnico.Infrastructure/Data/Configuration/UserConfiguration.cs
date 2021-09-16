using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.SobreNome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.Email).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.BirthDate).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.SchoolingId).HasColumnType("INT").IsRequired();

        }
    }
}