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
            CreateMap<CreateBrandViewModel, Brand>().ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src =>  DateTime.Now)); ;
            CreateMap<UpdateBrandViewModel, Brand>();
            CreateMap<Brand, BrandViewModel>();

            //Color

            CreateMap<CreateColorViewModel, Color>().ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateColorViewModel, Color>();
            CreateMap<Color, ColorViewModel>();

            //Category

            CreateMap<CreateCategoryViewModel, Category>().ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateCategoryViewModel, Category>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Category, CategoryTitleViewModel>();

            //Offer

            CreateMap<CreateOfferViewModel, Offer>().ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateOfferViewModel, Offer>();
            CreateMap<Offer, OfferViewModel>().ForMember(dest => dest.ProductViewModel, opt => opt.MapFrom(src => src.Product))
               .ForPath(dest=>dest.ProductViewModel.Brand,opt=>opt.MapFrom(src=>src.Product.Brand))
                .ForPath(dest => dest.ProductViewModel.Category, opt => opt.MapFrom(src => src.Product.Category))
                .ForPath(dest => dest.ProductViewModel.Color, opt => opt.MapFrom(src => src.Product.Color))
                .ForPath(dest => dest.ProductViewModel.Offers, opt => opt.MapFrom(src => src.Product.Offers))
                .ForPath(dest => dest.ProductViewModel.User, opt => opt.MapFrom(src => src.Product.User));
               
            CreateMap<OfferViewModel,Offer>(); 
            //Product
            CreateMap<CreateProductViewModel, Product>().ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel,Product >();

            // User
            CreateMap<User, UserViewModel>();



        }
    }
}
