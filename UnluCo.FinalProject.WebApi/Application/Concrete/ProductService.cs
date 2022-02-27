using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfwork, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfwork = unitOfwork;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }
        public void Add(CreateProductViewModel productViewModel)
        {
            var uniqueFileName = productViewModel.ProductImage;

            Product product = new Product()
            {
                IsActive = productViewModel.IsActive,
                IsOfferable = productViewModel.IsOfferable,
                IsSold = productViewModel.IsSold,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Description = productViewModel.Description,
                CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString())
            };
            product.Color = _unitOfwork.Colors.GetById(productViewModel.Color.Id).Result;
            product.Category = _unitOfwork.Categories.GetById(productViewModel.Category.Id).Result;
            product.Brand = _unitOfwork.Brands.GetById(productViewModel.Brand.Id).Result;
            product.User = _unitOfwork.Users.Get(u => u.Id == productViewModel.UserId).Result;
            product.ProductPicture = productViewModel.ProductImage;
            //if (uniqueFileName is not null)
            //{
            //    product.ProductPicture = uniqueFileName;
            //}
            _unitOfwork.Products.Add(product);
            _unitOfwork.Complete();
        }


        public void Delete(DeleteProductViewModel deleteProductViewModel)
        {
            var product = _unitOfwork.Products.GetProductDetails(p=>p.Id==deleteProductViewModel.Id).Result;
            _unitOfwork.Products.Delete(product);
            _unitOfwork.Complete();

        }

        public Task<ProductViewModel> Get(Expression<Func<Product, bool>> filter)
        {
            var product = _unitOfwork.Products.GetProductDetails(filter).Result;
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return Task.FromResult(productViewModel);
        }

        public Task<List<ProductViewModel>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var products = _unitOfwork.Products.GetProductsDetails(filter).Result;

            var productViewList = _mapper.Map<List<Product>, List<ProductViewModel>>(products);
            return Task.FromResult(productViewList);
        }

        public Task<ProductViewModel> GetById(int id)
        {
            var product = _unitOfwork.Products.GetProductDetails(p => p.Id == id).Result;
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return Task.FromResult(productViewModel);
        }

        public void Update(UpdateProductViewModel productViewModel)
        {
            Product product = new Product()
            {
                IsActive = productViewModel.IsActive,
                IsOfferable = productViewModel.IsOfferable,
                IsSold = productViewModel.IsSold,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Description = productViewModel.Description,
            };
            product.Color = _unitOfwork.Colors.GetById(productViewModel.Color.Id).Result;
            product.Category = _unitOfwork.Categories.GetById(productViewModel.Category.Id).Result;
            product.Brand = _unitOfwork.Brands.GetById(productViewModel.Brand.Id).Result;
            product.User = _unitOfwork.Users.Get(u => u.Id == productViewModel.UserId).Result;
           
            _unitOfwork.Products.Update(product);
            _unitOfwork.Complete();
        }
    }
}
