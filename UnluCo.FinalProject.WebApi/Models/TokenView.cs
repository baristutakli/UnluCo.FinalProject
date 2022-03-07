using System;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class TokenView
    {
        public string Token { get; set; }
        public DateTime expiration { get; set; }
    }
}
