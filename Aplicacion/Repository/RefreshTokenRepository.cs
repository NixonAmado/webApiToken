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
    public class RefreshTokenRepository : GenericRepository<RefreshToken>,IRefreshToken
    {
        private readonly TokenApiContext _context;

        public RefreshTokenRepository(TokenApiContext tokenApiContext) : base(tokenApiContext)
        {
            _context = tokenApiContext;
        }

   public async Task<RefreshToken> GetByTokenAsync(string token)
    {
            return await _context.RefreshTokens
            .SingleOrDefaultAsync(rt => rt.Token == token && rt.ExpirationDate > DateTime.UtcNow);
    }
    }
}