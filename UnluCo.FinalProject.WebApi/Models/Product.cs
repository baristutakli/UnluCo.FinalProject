using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Common.Entity;
using System.ComponentModel.DataAnnotations;
namespace UnluCo.FinalProject.WebApi.Models
{
    public class Product : BaseEntity
    {
        public bool IsOfferable { get; set; } = false;
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public bool IsSold { get; set; } = false;
        public Color Color { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public User User { get; set; }
        public UploadedFile ProductPicture { get; set; }

    }
}
