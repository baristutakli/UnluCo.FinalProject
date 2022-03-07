using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
namespace UnluCo.FinalProject.BlazorUI
{
    public class CreateOfferViewModel : ComponentBase
    {
        public int? Amount { get; set; }
        public int? Percentage { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
