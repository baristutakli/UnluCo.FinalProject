using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IBrandService
    {
        void Add(BrandViewModel brandViewModel);
        void Delete(DeleteBrandViewModel deleteBrandViewModel);
        void Update(UpdateBrandViewModel updateBrandViewModel);
        Task<List<BrandViewModel>> GetAll(Expression<Func<BrandViewModel, bool>> filter = null);
        Task<BrandViewModel> Get(Expression<Func<Brand, bool>> filter);
        Task<BrandViewModel> GetById(int id);

    }
}
