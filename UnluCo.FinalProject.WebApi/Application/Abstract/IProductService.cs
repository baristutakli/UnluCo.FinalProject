using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IProductService
    {

        bool Add(CreateProductViewModel createProductViewModel);
        bool Delete(DeleteProductViewModel deleteProductViewModel);
        bool Update(UpdateProductViewModel updateProductViewModel);
        Task<List<ProductViewModel>> GetAll(Expression<Func<Product, bool>> filter = null);
        Task<ProductViewModel> Get(Expression<Func<Product, bool>> filter);
        Task<ProductViewModel> GetById(int id);
    }
}
