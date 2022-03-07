using FluentValidation;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Offers
{
    public class CreateOfferViewModelValidator : AbstractValidator<CreateOfferViewModel>
    {
        public CreateOfferViewModelValidator()
        {

            RuleFor(vm => vm.Amount).GreaterThanOrEqualTo(0);
            RuleFor(vm => vm.Percentage).GreaterThanOrEqualTo(0);
            RuleFor(vm => vm.ProductId).NotNull().GreaterThan(0);

        }
    }
}
