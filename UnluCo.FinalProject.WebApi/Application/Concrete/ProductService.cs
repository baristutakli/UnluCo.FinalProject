using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;
using UnluCo.FinalProject.WebApi.DataAccess.UnitOfWorks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfwork, IMapper mapper)
        {
            _unitOfwork = unitOfwork;
            _mapper = mapper;
        }
        public void Add(CreateProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            _unitOfwork.Products.Add(product);
            _unitOfwork.Complete();
        }

        public void Delete(DeleteProductViewModel deleteProductViewModel)
        {
            var product = _unitOfwork.Products.GetById(deleteProductViewModel.Id).Result;
            _unitOfwork.Products.Delete(product);
            _unitOfwork.Complete();

        }

        public Task<ProductViewModel> Get(Expression<Func<Product, bool>> filter)
        {
            var product = _unitOfwork.Products.Get(filter).Result;
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return Task.FromResult(productViewModel);
        }

        public Task<List<ProductViewModel>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var products = _unitOfwork.Products.GetAll(filter).Result;

            var productViewList = _mapper.Map<List<Product>, List<ProductViewModel>>(products);
            return Task.FromResult(productViewList);
        }

        public Task<ProductViewModel> GetById(int id)
        {
            var product = _unitOfwork.Products.GetById(id).Result;
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return Task.FromResult(productViewModel);
        }

        public void Update(UpdateProductViewModel updateProductViewModel)
        {
            var product = _mapper.Map<Product>(updateProductViewModel);
            _unitOfwork.Products.Update(product);
            _unitOfwork.Complete();
        }
    }
}
