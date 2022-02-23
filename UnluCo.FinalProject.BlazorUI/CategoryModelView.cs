using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.BlazorUI
{
    public class CategoryModelView:ComponentBase
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public string Title { get; set; }
    }
}
