using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class RegisterAdminResponse
    {
        public IdentityResult Result { get; set; }
        public User User { get; set; }
    }
}
