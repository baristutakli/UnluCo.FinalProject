using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
