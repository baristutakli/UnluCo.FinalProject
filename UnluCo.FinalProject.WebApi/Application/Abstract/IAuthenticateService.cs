﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IAuthenticateService
    {
        public Task<IdentityResult> CreateUser(RegisterUserModel model);
        public Task<RegisterAdminResponse> CreateAdmin(RegisterUserModel model);

        public Task<bool> CheckUser(User user, UserLoginModel model);
        public Task<bool> CreateAdminRole(User user, string role);
        public Task<User> FindByEmailAsync(string username);
    }
}
