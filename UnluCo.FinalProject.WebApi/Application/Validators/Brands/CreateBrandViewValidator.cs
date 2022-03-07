using FluentValidation;
using UnluCo.FinalProject.WebApi.Application.ViewModels.BrandsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Brands
{
    public class CreateBrandViewValidator : AbstractValidator<CreateBrandViewModel>
    {
        public CreateBrandViewValidator()
        {
            RuleFor(b => b.Name).NotEmpty().NotNull();
        }
    }
}
