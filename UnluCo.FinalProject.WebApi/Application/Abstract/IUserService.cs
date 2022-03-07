using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.UsersViewModel;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IUserService
    {
        bool Add(UserViewModel userViewModel);
        bool Delete(DeleteUserViewModel deleteUserViewModel);
        bool Update(UserViewModel updateUserViewModel);
        Task<List<UserViewModel>> GetAll(Expression<Func<User, bool>> filter = null);
        Task<UserViewModel> Get(Expression<Func<User, bool>> filter);
        Task<UserViewModel> GetById(string id);

    }
}
