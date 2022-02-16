using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class FinalDbContext: IdentityDbContext<User>
    {
        public FinalDbContext(DbContextOptions<FinalDbContext> dbcontext):base(dbcontext)
        {

        }
        
        DbSet<Product> Products { get; set; }

    }
}
