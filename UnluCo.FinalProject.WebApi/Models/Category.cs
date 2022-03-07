using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UnluCo.FinalProject.WebApi.Common.Entity;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
