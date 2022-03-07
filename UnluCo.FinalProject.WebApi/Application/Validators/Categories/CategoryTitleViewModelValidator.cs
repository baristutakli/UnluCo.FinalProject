using FluentValidation;
using UnluCo.FinalProject.WebApi.Application.ViewModels.CategoriesViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Categories
{
    public class CategoryTitleViewModelValidator : AbstractValidator<CategoryTitleViewModel>
    {
        public CategoryTitleViewModelValidator()
        {
            RuleFor(vm => vm.Title).NotEmpty().NotNull();
        }
    }
}
