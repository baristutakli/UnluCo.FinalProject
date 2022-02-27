using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;

using UnluCo.FinalProject.WebApi.DataAccess.Abstract;
using UnluCo.FinalProject.WebApi.DataAccess.UnitOfWorks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfwork,IMapper mapper)
        {
            _unitOfwork = unitOfwork;
            _mapper = mapper;
        }
        public bool Add(CreateCategoryViewModel categoryViewModel)
        {
            var category =_mapper.Map<Category>(categoryViewModel);
            _unitOfwork.Categories.Add(category);
            var result =_unitOfwork.Complete();
            return result > 0 ? true : false;
        }

        public bool Delete(DeleteCategoryViewModel deleteCategoryViewModel)
        {
            var category =_unitOfwork.Categories.GetById(deleteCategoryViewModel.Id).Result;
            _unitOfwork.Categories.Delete(category);
            var result =_unitOfwork.Complete();
            return result > 0 ? true : false;
        }

        public Task<CategoryViewModel> Get(Expression<Func<Category, bool>> filter)
        {
            var category = _unitOfwork.Categories.Get(filter).Result;
            var categoryViewModel=_mapper.Map<CategoryViewModel>(category);
            return Task.FromResult(categoryViewModel);
        }

        public Task<List<CategoryViewModel>> GetAll(Expression<Func<CategoryViewModel, bool>> filter = null)
        {
            var categorys = _unitOfwork.Categories.GetProductsByCategory().Result;
            
            var categoryViewList = _mapper.Map<List<Category>, List<CategoryViewModel>>(categorys);
            return Task.FromResult(categoryViewList);
        }
        public Task<List<CategoryTitleViewModel>> GetAllTitles(Expression<Func<CategoryTitleViewModel, bool>> filter = null)
        {
            var categorys = _unitOfwork.Categories.GetAll().Result;

            var categoryViewList = _mapper.Map<List<Category>, List<CategoryTitleViewModel>>(categorys);
            return Task.FromResult(categoryViewList);
        }

        public Task<CategoryViewModel> GetById(int id)
        {
            var category = _unitOfwork.Categories.GetProductsByASpecificCategory(c=>c.Id==id).Result;
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return Task.FromResult(categoryViewModel);
        }

        public bool Update(int id,CreateCategoryViewModel updateCategoryViewModel)
        {
           var category= _mapper.Map<Category>(updateCategoryViewModel);
            _unitOfwork.Categories.Update(category);
            var result =_unitOfwork.Complete();
            return result > 0 ? true : false;
        }
    }
}
