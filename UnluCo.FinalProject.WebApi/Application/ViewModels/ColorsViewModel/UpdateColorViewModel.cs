using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.WebApi.Application.ViewModels.ColorsViewModel
{
    public class UpdateColorViewModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
