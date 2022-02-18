using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class BrandService : IBrandService
    {
        public void Add(Brand product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand product)
        {
            throw new NotImplementedException();
        }

        public Task<Brand> Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Brand> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand product)
        {
            throw new NotImplementedException();
        }
    }
}
