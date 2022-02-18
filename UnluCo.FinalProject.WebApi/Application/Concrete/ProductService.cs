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

        public ProductService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public void Add(ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(DeleteProductViewModel deleteProductViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductViewModel>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateProductViewModel updateProductViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
