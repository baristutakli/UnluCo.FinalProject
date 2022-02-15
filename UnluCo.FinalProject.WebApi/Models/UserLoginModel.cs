using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace UnluCo.FinalProject.WebApi.Models
{
    public class UserLoginModel
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
