using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.OffersViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Offers
{
    public class UpdateOfferViewModelValidator:AbstractValidator<UpdateOfferViewModel>
    {
        public UpdateOfferViewModelValidator()
        {
            RuleFor(vm => vm.Amount).GreaterThanOrEqualTo(0);
            RuleFor(vm => vm.Percentage).GreaterThanOrEqualTo(0);
            RuleFor(vm => vm.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
