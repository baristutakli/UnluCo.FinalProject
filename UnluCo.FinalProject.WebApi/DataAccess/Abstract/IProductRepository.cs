using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Common.Repositories;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<List<Product>> GetProductsDetails(Expression<Func<Product, bool>> filter = null);
        public Task<Product> GetProductDetails(Expression<Func<Product, bool>> filter);
    }
}
