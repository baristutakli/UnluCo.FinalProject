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
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context)
        {

        }
        public override async Task<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return filter == null ? await _dbcontext.Set<User>()
                .Include(c => c.Products).ThenInclude(p => p.Color)
                .Include(c => c.Products).ThenInclude(p => p.Category)
                .Include(c => c.Products).ThenInclude(p => p.Brand)
                .Include(c => c.Products).ThenInclude(p => p.User)
                .Include(c => c.Products).ThenInclude(p => p.Offers)
                .ToListAsync() 
                : await _dbcontext.Set<User>()
                .Include(c => c.Products).ThenInclude(p => p.Color)
                .Include(c => c.Products).ThenInclude(p => p.Category)
                .Include(c => c.Products).ThenInclude(p => p.Brand)
                .Include(c => c.Products).ThenInclude(p => p.User)
                .Include(c => c.Products).ThenInclude(p => p.Offers).Where(filter).ToListAsync();
        }


        public async Task<User> GetUserWithOffers(string id)
        {
            return await _dbcontext.Set<User>().Include(c => c.Products).ThenInclude(p => p.Offers).SingleAsync(x => x.Id == id);
        }

        public async Task<User> GetUserWithProducts(string id)
        {
            return await _dbcontext.Set<User>()
                .Include(c => c.Products).ThenInclude(p => p.Color)
                .Include(c => c.Products).ThenInclude(p => p.Category)
                .Include(c => c.Products).ThenInclude(p => p.Brand)
                .Include(c => c.Products).ThenInclude(p => p.User)
                .SingleAsync(x => x.Id == id);
        }
        public async Task<User> GetUserWithAll(string id)
        {
            return await _dbcontext.Set<User>()
                .Include(c => c.Products).ThenInclude(p => p.Color)
                .Include(c => c.Products).ThenInclude(p => p.Category)
                .Include(c => c.Products).ThenInclude(p => p.Brand)
                .Include(c => c.Products).ThenInclude(p => p.User)
                .Include(c => c.Products).ThenInclude(p => p.Offers).SingleAsync(x => x.Id == id);
        }
    }
}
