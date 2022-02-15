using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.DataAccess.Abstract
{
    public interface IUserRepository
    {
        Task<int> Add(User user);
        Task<int> Delete(User user);
        Task<int> Update(User user);
        Task<List<User>> GetAll(Expression<Func<User, bool>> filter = null);
        Task<User> GetById(int id);
        Task<IList<User>> Get(Expression<Func<User, bool>> filter);
       

    }
}
