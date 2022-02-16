using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.WebApi.Common.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetById(int id);
        Task<ICollection<TEntity>> Get(Expression<Func<TEntity, bool>> filter);
    }
}
