using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;
using UnluCo.FinalProject.WebApi.DataAccess.Abstract;
using UnluCo.FinalProject.WebApi.DataAccess.UnitOfWorks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfwork;

        public BrandService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public void Add(BrandViewModel brandViewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(DeleteBrandViewModel deleteBrandViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<BrandViewModel> Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Brand>> GetAll(Expression<Func<BrandViewModel, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<BrandViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateBrandViewModel updateBrandViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
