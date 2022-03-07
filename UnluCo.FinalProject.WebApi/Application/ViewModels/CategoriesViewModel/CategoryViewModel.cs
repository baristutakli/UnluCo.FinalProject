using System.Collections.Generic;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public string Title { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }
    }
}
