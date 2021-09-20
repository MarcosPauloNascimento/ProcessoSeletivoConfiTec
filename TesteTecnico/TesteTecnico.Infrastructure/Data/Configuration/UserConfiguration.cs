using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteTecnico.Entities.Entities;

namespace TesteTecnico.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.Sobrenome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.Email).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(u => u.DataNascimento).HasColumnType("DATETIME").IsRequired();
            builder.Property(u => u.EscolaridadeId).HasColumnType("INT").IsRequired();

        }
    }
}