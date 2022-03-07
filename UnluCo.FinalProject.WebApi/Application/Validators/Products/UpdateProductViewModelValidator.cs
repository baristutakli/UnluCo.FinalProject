using FluentValidation;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Products
{
    public class UpdateProductViewModelValidator : AbstractValidator<UpdateProductViewModel>
    {
        public UpdateProductViewModelValidator()
        {
            RuleFor(vm => vm.Id).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(vm => vm.IsOfferable).NotNull();
            RuleFor(vm => vm.Name).MaximumLength(100).NotNull().NotEmpty();
            RuleFor(vm => vm.Description).MaximumLength(500).NotEmpty().NotNull();
            RuleFor(vm => vm.Price).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(vm => vm.Color).NotNull();
            RuleFor(vm => vm.Brand).NotNull();
            RuleFor(vm => vm.Category).NotNull();
            RuleFor(vm => vm.UserId).NotNull();
        }
    }
}
