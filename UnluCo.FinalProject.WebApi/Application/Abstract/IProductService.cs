using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IProductService
    {

        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        Task<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null);
        Task<Product> Get(Expression<Func<Product, bool>> filter);
        Task<Product> GetById(int id);
    }
}
