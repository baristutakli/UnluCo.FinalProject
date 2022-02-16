using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class FinalDbContext : IdentityDbContext<User>
    {
        public FinalDbContext(DbContextOptions<FinalDbContext> dbcontext) : base(dbcontext)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

    }
}
