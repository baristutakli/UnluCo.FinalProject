using FluentValidation;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ColorsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Colors
{
    public class CreateColorViewValidator : AbstractValidator<CreateColorViewModel>
    {
        public CreateColorViewValidator()
        {
            RuleFor(b => b.Name).NotEmpty().NotNull();
        }
    }
}
