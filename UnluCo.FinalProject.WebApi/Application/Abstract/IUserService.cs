using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        Task<List<User>> GetAll(Expression<Func<User, bool>> filter = null);
        Task<User> Get(Expression<Func<User, bool>> filter);
        Task<User> GetById(int id);

    }
}
