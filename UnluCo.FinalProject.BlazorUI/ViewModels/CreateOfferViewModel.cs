using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.ViewModels.ProductsViewModel;
using System.ComponentModel.DataAnnotations;
namespace UnluCo.FinalProject.BlazorUI
{
    public class CreateOfferViewModel : ComponentBase
    {
        public int? Amount { get; set; }
        public int? Percentage { get; set; }
        [Required]
        public int ProductId{ get; set; }
    }
}
