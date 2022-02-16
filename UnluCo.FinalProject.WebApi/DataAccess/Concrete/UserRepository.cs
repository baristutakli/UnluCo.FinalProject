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
    public class UserRepository :Repository<User>, IUserRepository
    {
        public UserRepository(FinalDbContext context):base(context)
        {

        }

        public async Task<User> GetUserWithOffers(string id)
        {
            return await _dbcontext.Set<User>().Include("Offers").SingleAsync(x=>x.Id==id);
        }

        public async  Task<User> GetUserWithProducts(string id)
        {
            return await _dbcontext.Set<User>().Include("Products").SingleAsync(x => x.Id == id);
        }
        public async Task<User> GetUserWithAll(string id)
        {
            return await _dbcontext.Set<User>().Include("Products").Include("Offers").SingleAsync(x => x.Id == id);
        }
    }
}
