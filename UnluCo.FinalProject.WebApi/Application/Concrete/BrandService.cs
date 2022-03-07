﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;
using UnluCo.FinalProject.WebApi.DataAccess.UnitOfWorks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork unitOfwork, IMapper mapper)
        {
            _unitOfwork = unitOfwork;
            _mapper = mapper;
        }
        public bool Add(CreateBrandViewModel brandViewModel)
        {
            var brand = _mapper.Map<Brand>(brandViewModel);
            _unitOfwork.Brands.Add(brand);
            var result = _unitOfwork.Complete();
            return result > 0;
        }

        public bool Delete(DeleteBrandViewModel deleteBrandViewModel)
        {
            var brand = _unitOfwork.Brands.GetById(deleteBrandViewModel.Id).Result;
            _unitOfwork.Brands.Delete(brand);
            var result = _unitOfwork.Complete();
            return result > 0;

        }

        public Task<BrandViewModel> Get(Expression<Func<Brand, bool>> filter)
        {
            var brand = _unitOfwork.Brands.Get(filter).Result;
            var brandViewModel = _mapper.Map<BrandViewModel>(brand);

            return Task.FromResult(brandViewModel);
        }

        public Task<List<BrandViewModel>> GetAll(Expression<Func<BrandViewModel, bool>> filter = null)
        {
            var brands = _unitOfwork.Brands.GetAll().Result;

            var brandViewList = _mapper.Map<List<Brand>, List<BrandViewModel>>(brands);
            return Task.FromResult(brandViewList);
        }

        public Task<BrandViewModel> GetById(int id)
        {
            var brand = _unitOfwork.Brands.GetById(id).Result;
            var brandViewModel = _mapper.Map<BrandViewModel>(brand);
            return Task.FromResult(brandViewModel);
        }

        public bool Update(int id, UpdateBrandViewModel updateBrandViewModel)
        {
            var selectedBrand = _unitOfwork.Brands.GetById(id).Result;
            var brand = _mapper.Map(updateBrandViewModel, selectedBrand);
            _unitOfwork.Brands.Update(brand);
            var result = _unitOfwork.Complete();
            return result > 0;
        }
    }
}
