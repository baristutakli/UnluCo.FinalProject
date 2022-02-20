using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Categories
{
    public class UpdateCategoryviewModelValidator:AbstractValidator<CreateCategoryViewModel>
    {
        public UpdateCategoryviewModelValidator()
        {
            RuleFor(vm => vm.IsActive).NotNull();
            RuleFor(vm => vm.Id).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(vm => vm.Title).NotNull().NotEmpty().MaximumLength(300);
        }
    }
}
