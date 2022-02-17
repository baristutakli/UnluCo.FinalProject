using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Common.Repositories;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.DataAccess.Abstract
{
    public interface IUserRepository:IRepository<User>
    {
        public Task<User> GetUserWithProducts(string id);
        public Task<User> GetUserWithOffers(string id);

        public Task<User> GetUserWithAll(string id);
    }
    
}
