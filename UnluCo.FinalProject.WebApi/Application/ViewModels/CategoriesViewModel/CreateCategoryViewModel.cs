using System.Collections.Generic;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel
{
    public class CreateCategoryViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public string Title { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
