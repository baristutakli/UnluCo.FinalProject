using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Common.Repositories;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.DataAccess.Abstract
{
    public interface ICategoryRepository: IRepository<Category>
    {
        public Task<List<Category>> GetProductsByCategory(Expression<Func<Category, bool>> filter = null);
    }
}
