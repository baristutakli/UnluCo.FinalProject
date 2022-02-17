using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.Concrete;
using UnluCo.FinalProject.WebApi.DataAccess.Abstract;
using UnluCo.FinalProject.WebApi.DataAccess.Concrete;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Common.DependencyResolver
{
    public static class DependencyContainer
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();


            services.AddScoped<UserManager<User>>();

        }
    }
}
