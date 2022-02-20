using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Categories
{
    public class CategoryTitleViewModelValidator:AbstractValidator<CategoryTitleViewModel>
    {
        public CategoryTitleViewModelValidator()
        {
            RuleFor(vm => vm.Title).NotEmpty().NotNull();
        }
    }
}
