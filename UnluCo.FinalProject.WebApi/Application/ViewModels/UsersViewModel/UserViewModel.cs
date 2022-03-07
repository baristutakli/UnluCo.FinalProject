using System.Collections.Generic;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.ViewModels.UsersViewModel
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }
        public ICollection<OfferViewModel> Offers { get; set; }
    }
}
