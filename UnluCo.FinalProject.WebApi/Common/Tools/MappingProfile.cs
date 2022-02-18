using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ColorsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.UsersViewModel;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Common.Tools
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Brand
            CreateMap<CreateBrandViewModel, Brand>();
            CreateMap<UpdateBrandViewModel, Brand>();
            CreateMap<Brand, BrandViewModel>();

            //Color

            CreateMap<CreateColorViewModel, Color>();
            CreateMap<UpdateColorViewModel, Color>();
            CreateMap<Color, ColorViewModel>();

            //Category

            CreateMap<CreateCategoryViewModel, Category>();
            CreateMap<UpdateCategoryViewModel, Category>();
            CreateMap<Category, CategoryTitleViewModel>();

            //Offer

            CreateMap<CreateOfferViewModel, Offer>();
            CreateMap<UpdateOfferViewModel, Offer>();
            CreateMap<Offer, OfferViewModel>();

            //Product
            CreateMap<CreateProductViewModel, Product>();
            CreateMap<UpdateProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();


            // User
            CreateMap<User, UserViewModel>();



        }
    }
}
