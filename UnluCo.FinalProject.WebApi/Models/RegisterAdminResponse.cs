using Microsoft.AspNetCore.Identity;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class RegisterAdminResponse
    {
        public IdentityResult Result { get; set; }
        public User User { get; set; }
    }
}
