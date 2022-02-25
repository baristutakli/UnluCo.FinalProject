using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface ICategoryService
    {
        void Add(CreateCategoryViewModel categoryViewModel);
        void Delete(DeleteCategoryViewModel deleteCategoryViewModel);
        void Update(int id,CreateCategoryViewModel updateCategoryViewModel);
        Task<List<CategoryViewModel>> GetAll(Expression<Func<CategoryViewModel, bool>> filter = null);
        Task<CategoryViewModel> Get(Expression<Func<Category, bool>> filter);
        Task<CategoryViewModel> GetById(int id);
        Task<List<CategoryTitleViewModel>> GetAllTitles(Expression<Func<CategoryTitleViewModel, bool>> filter = null);
    }
}
