using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; } // a quien realizo la solicitud
        public double DurationInMinutes { get; set; } //tiempo antes de que caduque // limite de tiempo
    }
}