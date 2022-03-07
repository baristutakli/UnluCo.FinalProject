using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace UnluCo.FinalProject.BlazorUI
{
    public class CategoryModelView : ComponentBase
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public string Title { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }
    }
}
