using AutoMapper;
using System;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ColorsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.UsersViewModel;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Common.Tools
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            // Brand
            CreateMap<CreateBrandViewModel, Brand>().ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now)); ;
            CreateMap<UpdateBrandViewModel, Brand>();
            CreateMap<Brand, BrandViewModel>();

            //Color

            CreateMap<CreateColorViewModel, Color>().ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateColorViewModel, Color>();
            CreateMap<Color, ColorViewModel>();

            //Category

            CreateMap<CreateCategoryViewModel, Category>().ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Category, CategoryTitleViewModel>();
            CreateMap<Category, CategoryViewModel>().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            //Offer

            CreateMap<CreateOfferViewModel, Offer>().ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateOfferViewModel, Offer>();
            CreateMap<Offer, OfferViewModel>().ForMember(dest => dest.ProductViewModel, opt => opt.MapFrom(src => src.Product))
               .ForPath(dest => dest.ProductViewModel.Brand, opt => opt.MapFrom(src => src.Product.Brand))
                .ForPath(dest => dest.ProductViewModel.Category, opt => opt.MapFrom(src => src.Product.Category))
                .ForPath(dest => dest.ProductViewModel.Color, opt => opt.MapFrom(src => src.Product.Color))
                .ForPath(dest => dest.ProductViewModel.Offers, opt => opt.MapFrom(src => src.Product.Offers))
                .ForPath(dest => dest.ProductViewModel.User, opt => opt.MapFrom(src => src.Product.User));

            CreateMap<OfferViewModel, Offer>();


            //CreateMap<CreateProductViewModel, Product>()
            //    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            //    .ForPath(dest => _unitOfwork.Colors.GetById(dest.Color.Id).Result, opt => opt.MapFrom(src => src.Color))
            //    .ForPath(dest => _unitOfwork.Categories.GetById(dest.Category.Id).Result, opt => opt.MapFrom(src => src.Category))
            //    .ForPath(dest => _unitOfwork.Brands.GetById(dest.Brand.Id).Result, opt => opt.MapFrom(src => src.Brand))
            //    .ForPath(dest => _unitOfwork.Users.Get(u => u.Id == dest.User.Id).Result, opt => opt.MapFrom(src => src.UserId)).ReverseMap();


            CreateMap<UpdateProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>()
                .ForPath(dest => dest.UploadedFile, opt => opt.MapFrom(src => src.ProductPicture));
            CreateMap<ProductViewModel, Product>();

            // User
            CreateMap<User, UserViewModel>();



        }
    }
}
