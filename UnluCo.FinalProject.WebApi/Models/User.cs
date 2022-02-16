using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Product> Products { get; set; }
        public virtual Offer Offers{ get; set; }
    }
}
