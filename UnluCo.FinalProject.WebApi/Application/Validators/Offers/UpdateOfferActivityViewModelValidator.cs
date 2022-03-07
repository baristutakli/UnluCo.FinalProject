using FluentValidation;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Offers
{
    public class UpdateOfferActivityViewModelValidator : AbstractValidator<UpdateOfferActivityViewModel>
    {
        public UpdateOfferActivityViewModelValidator()
        {
            RuleFor(vm => vm.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
