using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }= string.Empty;
        public string Email { get; set; }= string.Empty;
        public string Password { get; set; }= string.Empty;
        public ICollection<RefreshToken> RefreshToken {get;set;}
        public ICollection<Rol> Rols { get; set; } = new HashSet<Rol>();
        public ICollection<UserRol> UsersRols { get; set; }

    }
}