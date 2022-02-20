using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ColorsViewModel;

namespace UnluCo.FinalProject.WebApi.Application.Validators.Colors
{
    public class CreateColorViewValidator:AbstractValidator<CreateColorViewModel>
    {
        public CreateColorViewValidator()
        {
            RuleFor(b => b.Name).NotEmpty().NotNull();
        }
    }
}
