using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Common.Repositories;
using UnluCo.FinalProject.WebApi.DataAccess.Abstract;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.DataAccess.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(UserDbContext context):base(context)
        {

        }
        public async Task<List<Product>> GetProductsDetails(Expression<Func<Product, bool>> filter = null)
        {
            return filter == null ? await _dbcontext.Set<Product>().Include("Colors").Include("Brands").Include("Categories").Include("Users").Include("Offers").ToListAsync() : await _dbcontext.Set<Product>().Include("Colors").Include("Brands").Include("Categories").Include("Users").Where(filter).ToListAsync();
        }
        public async Task<Product> GetProductDetails(Expression<Func<Product, bool>> filter)
        {
            return  await _dbcontext.Set<Product>().Include("Colors").Include("Brands").Include("Categories").Include("Users").Include("Offers").FirstOrDefaultAsync(filter) ;
        }

    }
}
