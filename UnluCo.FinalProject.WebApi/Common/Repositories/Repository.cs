using Microsoft.EntityFrameworkCore;
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
        protected readonly UserDbContext _dbcontext;
        public Repository(UserDbContext dbContext)
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

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {

            return await _dbcontext.Set<TEntity>().Where(filter).SingleOrDefaultAsync();
        }

        public virtual async  Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? await _dbcontext.Set<TEntity>().ToListAsync() : await _dbcontext.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbcontext.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Update(entity);
        }
    }
}
