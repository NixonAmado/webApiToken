using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class UserRol : BaseEntity
    {
        public int IdUserFk { get; set; }
        public User User { get; set; }
        public int IdRolFk { get; set; }
        public Rol Rol { get; set; }
    
    
    }
}