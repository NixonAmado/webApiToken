using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;

public class TokenApiContext : DbContext
{
    public TokenApiContext(DbContextOptions <TokenApiContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<UserRol> UsersRols { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder
        // .Entity<UserRol>(builder => {
        //   builder.HasNoKey();
        // });



        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}
