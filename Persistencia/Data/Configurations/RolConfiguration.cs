using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder <Rol> builder)
    {
        builder.ToTable("Rol");
        builder.Property(p => p.Name)
        // una manera de cambiar el nombre de las tablas
            .HasColumnName("RolNames")
            .IsRequired()
            .HasMaxLength(30);

             builder
        .HasMany(p => p.Users)
        .WithMany(p => p.Rols)
        .UsingEntity<UserRol>
        (    
            j => j 
            .HasOne(p => p.User)
            .WithMany(p => p.UsersRols)
            .HasForeignKey( p => p.IdUserFk),
        
            j => j 
            .HasOne(p => p.Rol)
            .WithMany(p => p.UsersRols)
            .HasForeignKey( p => p.IdRolFk),
            j =>
            {
                j.HasKey(t => new { t.IdUserFk, t.IdRolFk});
            }

        );
    }
}


    