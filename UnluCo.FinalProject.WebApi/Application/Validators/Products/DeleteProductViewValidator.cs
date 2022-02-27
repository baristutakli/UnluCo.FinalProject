using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Brands
{
    public class DeleteProductViewValidator:AbstractValidator<DeleteProductViewModel>
    {
        public DeleteProductViewValidator()
        {
            RuleFor(b => b.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
