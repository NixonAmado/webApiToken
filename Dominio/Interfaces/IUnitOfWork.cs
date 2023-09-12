using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        IRol Rols { get; }
        IUser Users { get; }
        IRefreshToken RefreshTokens { get; }

        Task<int> SaveAsync();
    
    }
}