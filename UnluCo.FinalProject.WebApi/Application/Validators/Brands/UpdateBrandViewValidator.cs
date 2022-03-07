﻿using FluentValidation;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Brands
{
    public class UpdateBrandViewValidator : AbstractValidator<UpdateBrandViewModel>
    {
        public UpdateBrandViewValidator()
        {
            RuleFor(b => b.Name).NotEmpty().NotNull();
        }
    }
}
