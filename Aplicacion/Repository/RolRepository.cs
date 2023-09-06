using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repositiory;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class RolRepository : GenericRepository<Rol>,IRol
    {
        private readonly TokenApiContext _context;

        public RolRepository(TokenApiContext tokenApiContext) : base(tokenApiContext)
        {
            _context = tokenApiContext;
        }

        // public async Task<Rol> GetRolByNameAsync(string RolName)
        // {
        //     return await _context.Rols
        //                 .Include(u => u.Users)
        //                 .FirstOrDefaultAsync(u => u.Name.ToLower() == RolName.ToLower());
        // }
    }
}