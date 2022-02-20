using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Brands
{
    public class DeleteBrandViewValidator:AbstractValidator<DeleteBrandViewModel>
    {
        public DeleteBrandViewValidator()
        {
            RuleFor(b => b.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
