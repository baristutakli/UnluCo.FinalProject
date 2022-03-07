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
        public ProductRepository(UserDbContext context) : base(context)
        {

        }
        public async Task<List<Product>> GetProductsDetails(Expression<Func<Product, bool>> filter = null)
        {
            return filter == null ? await _dbcontext.Set<Product>().Include(p => p.Color).Include(p => p.Brand).Include(p => p.Category).Include(p => p.User).Include(p => p.Offers).Include(p => p.ProductPicture).ToListAsync() : await _dbcontext.Set<Product>().Include(p => p.Color).Include(p => p.Brand).Include(p => p.Category).Include(p => p.User).Include(p => p.Offers).Include(p => p.ProductPicture).Where(filter).ToListAsync();
        }
        public async Task<Product> GetProductDetails(Expression<Func<Product, bool>> filter)
        {
            return await _dbcontext.Set<Product>().Include(p => p.Color).Include(p => p.Brand).Include(p => p.Category).Include(p => p.User).Include(p => p.Offers).Include(p => p.ProductPicture).FirstOrDefaultAsync(filter);
        }
        public override void Delete(Product product)
        {

            if (product.Offers.Count > 0)
            {
                foreach (var offer in product.Offers)
                {
                    offer.Product = null;
                    _dbcontext.Set<Offer>().Remove(offer);
                }
            }
            _dbcontext.Set<Product>().Remove(product);
        }
    }
}
