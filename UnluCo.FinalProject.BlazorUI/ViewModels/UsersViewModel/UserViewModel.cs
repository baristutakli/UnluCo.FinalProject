using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace UnluCo.FinalProject.BlazorUI
{
    public class UserViewModel : ComponentBase
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }
        public ICollection<OfferViewModel> Offers { get; set; }
    }
}
