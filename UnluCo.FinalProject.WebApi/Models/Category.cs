using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Common.Entity;
using System.ComponentModel.DataAnnotations;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class Category: BaseEntity
    {
        [Required]
        public string Title { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
