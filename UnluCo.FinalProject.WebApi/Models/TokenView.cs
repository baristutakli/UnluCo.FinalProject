using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class TokenView
    {
        public string Token { get; set; }
        public DateTime expiration { get; set; }
    }
}
