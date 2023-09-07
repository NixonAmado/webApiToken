
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.Property(p => p.UserName)
        // una manera de cambiar el nombre de las tablas
        .HasColumnName("UserNames")
        .IsRequired()
        .HasMaxLength(30);

        builder.Property("Email")
        .IsRequired()
        .HasMaxLength(30);
        
        builder.Property("Password")
        .IsRequired()
        .HasMaxLength(255);
        

    }
}
