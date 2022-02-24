using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace UnluCo.FinalProject.BlazorUI
{
    public class UserLoginModel : ComponentBase
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8),MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
