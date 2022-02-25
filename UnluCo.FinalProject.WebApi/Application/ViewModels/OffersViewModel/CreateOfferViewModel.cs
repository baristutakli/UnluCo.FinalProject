using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel
{
    public class CreateOfferViewModel
    {
        public int? Amount { get; set; }
        public int? Percentage { get; set; }
        public int ProductId{ get; set; }
    }
}
