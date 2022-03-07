using FluentValidation;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ColorsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Colors
{
    public class UpdateColorViewValidator : AbstractValidator<UpdateColorViewModel>
    {
        public UpdateColorViewValidator()
        {
            RuleFor(b => b.Name).NotEmpty().NotNull();
        }
    }
}
