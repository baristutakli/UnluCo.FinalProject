using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ColorsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;
using UnluCo.FinalProject.WebApi.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;
using System.Net.Http;

namespace UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel
{
    public class CreateProductViewModel
    {
    
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
        public string UserId { get; set; }
        public UploadedFile ProductImage { get; set; }
    }
}
