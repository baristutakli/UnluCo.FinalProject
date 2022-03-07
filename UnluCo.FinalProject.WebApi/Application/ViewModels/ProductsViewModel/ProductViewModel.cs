﻿using System;
using System.Collections.Generic;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ColorsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsOfferable { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
        public bool IsSold { get; set; } = false;
        public ColorViewModel Color { get; set; }
        public BrandViewModel Brand { get; set; }
        public CategoryTitleViewModel Category { get; set; }
        public List<OfferViewModel> Offers { get; set; }
        public User User { get; set; }
        public UploadedFile UploadedFile { get; set; }
    }
}
