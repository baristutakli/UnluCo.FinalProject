using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;

namespace UnluCo.FinalProject.BlazorUI
{
    public class UpdateOfferActivityViewModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int ProductId { get; set; }
    }
}
