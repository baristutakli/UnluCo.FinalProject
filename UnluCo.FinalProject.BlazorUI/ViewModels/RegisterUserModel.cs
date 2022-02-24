using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace UnluCo.FinalProject.BlazorUI

{
    public class RegisterUserModel : ComponentBase
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8), MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
