using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IBrandService
    {
        void Add(Brand product);
        void Delete(Brand product);
        void Update(Brand product);
        Task<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null);
        Task<Brand> Get(Expression<Func<Brand, bool>> filter);
        Task<Brand> GetById(int id);

    }
}
