using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Categories
{
    public class CreateCategoryviewModelValidator:AbstractValidator<CreateCategoryViewModel>
    {
        public CreateCategoryviewModelValidator()
        {
            RuleFor(vm => vm.IsActive).NotNull();
            RuleFor(vm => vm.Title).NotNull().NotEmpty().MaximumLength(300);
        }
    }
}
