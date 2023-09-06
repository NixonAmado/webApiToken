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
    public class UserRepository : GenericRepository<User>,IUser
    {
        private readonly TokenApiContext _context;

        public UserRepository(TokenApiContext tokenApiContext) : base(tokenApiContext)
        {
            _context = tokenApiContext;
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await _context.Users
                        .Include(u => u.Rols)
                        .FirstOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower());
        }
    }
}