using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DatosUsuarioDto
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string  UserName { get; set; }
        public string Email { get; set; }
        public List<string> Rols { get; set; }
        public string Token { get; set; }
    }
}