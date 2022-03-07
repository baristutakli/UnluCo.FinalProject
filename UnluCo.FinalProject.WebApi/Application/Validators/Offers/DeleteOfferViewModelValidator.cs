using FluentValidation;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Brands
{
    public class DeleteOfferViewModelValidator : AbstractValidator<DeleteOfferViewModel>
    {
        public DeleteOfferViewModelValidator()
        {
            RuleFor(b => b.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
