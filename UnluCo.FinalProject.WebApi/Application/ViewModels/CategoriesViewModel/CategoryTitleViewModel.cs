using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel
{
    public class CategoryTitleViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public string Title { get; set; }
        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}
