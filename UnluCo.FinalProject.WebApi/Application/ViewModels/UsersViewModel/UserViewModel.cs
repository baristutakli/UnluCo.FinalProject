using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.WebApi.Application.ViewModels.UsersViewModel
{
    public class UserViewModel
    {
        public  string Email { get; set; }
        public virtual string UserName { get; set; }
    }
}
