using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.DataAccess.Abstract;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly FinalDbContext _dbcontext;
        private readonly DbSet<User> _dbSet;
        public UserRepository(FinalDbContext context)
        {
            _dbcontext = context;
            _dbSet = _dbcontext.Set<User>();
        }
        public async Task<int> Add(User user)
        {
            await _dbSet.AddAsync(user);
            return await _dbcontext.SaveChangesAsync();
        }

        public async Task<int> Delete(User user)
        {
            _dbSet.Remove(user);
            return await _dbcontext.SaveChangesAsync();
        }

        public async  Task<List<User>> Get(Expression<Func<User, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public Task<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return filter == null ? _dbSet.ToListAsync(): _dbSet.Where(filter).ToListAsync();
   
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(User user)
        {
            _dbSet.Update(user);
            return await _dbcontext.SaveChangesAsync();
        }
    }
}
