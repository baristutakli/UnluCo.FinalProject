using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Common.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly FinalDbContext _dbcontext;
        public Repository(FinalDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public void Add(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Remove(entity);
        }

        public async Task<ICollection<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
        {
          
           return  filter == null ? await _dbcontext.Set<TEntity>().ToList() :  .Where(filter).ToListAsync();
        }

        public Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Update(entity);
        }
    }
}
