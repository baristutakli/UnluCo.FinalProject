using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;

namespace UnluCo.FinalProject.BlazorUI
{
    public class UserViewModel : ComponentBase
    {
        public  string Email { get; set; }
        public string UserName { get; set; }
        public  ICollection<ProductViewModel> Products { get; set; }
        public  ICollection<OfferViewModel> Offers { get; set; }
    }
}
