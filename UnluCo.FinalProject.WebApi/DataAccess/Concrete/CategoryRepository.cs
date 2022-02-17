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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(UserDbContext context):base(context)
        {

        }

        public async Task<List<Category>> GetProductsByCategory(Expression<Func<Category, bool>> filter = null)
        {
            return filter == null ? await _dbcontext.Set<Category>().Include("Products").ToListAsync() : await _dbcontext.Set<Category>().Include("Products").Where(filter).ToListAsync();

        }
    }
}
