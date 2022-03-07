﻿using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel
{
    public class OfferViewModel
    {
        public int Id { get; set; }
        public int? Amount { get; set; }
        public int? Percentage { get; set; }
        public ProductViewModel ProductViewModel { get; set; }
    }
}
