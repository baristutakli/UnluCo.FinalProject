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
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;
using System.Net.Http;
using UnluCo.FinalProject.BlazorUI.ViewModels;
using UploadedFile = UnluCo.FinalProject.BlazorUI.ViewModels.UploadedFile;

namespace UnluCo.FinalProject.BlazorUI
{
    public class CreateProductViewModel : ComponentBase
    {

        public bool IsActive { get; set; }
        public bool IsOfferable { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsSold { get; set; } = false;
        [Required]
        public ColorViewModel Color { get; set; }
        [Required]
        public BrandViewModel Brand { get; set; }
        [Required]
        public CategoryTitleViewModel Category { get; set; }
        public string UserId { get; set; }
        [Required, MaxLength(406900)]
        public UploadedFile ProductImage { get; set; }
    }
}
