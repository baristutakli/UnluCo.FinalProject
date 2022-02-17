using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class MainDbContext:DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> dbcontext) : base(dbcontext)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<Offer> Offers { get; set; }
        public  DbSet<Color> Colors { get; set; }
        public  DbSet<Brand> Brands { get; set; }
        public  DbSet<Category> Categories { get; set; }
    }
}
