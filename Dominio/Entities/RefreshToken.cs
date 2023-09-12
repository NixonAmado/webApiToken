using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;

    public class RefreshToken : BaseEntity
    {
        public required string Token {get;set;}
        public DateTime ExpirationDate {get;set;} 
        //referencia al usuario
        public int IdUserFk {get;set;}
        public User User {get;set;}
    }
