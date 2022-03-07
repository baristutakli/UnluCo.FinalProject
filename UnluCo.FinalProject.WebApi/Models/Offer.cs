using System.ComponentModel.DataAnnotations;
using UnluCo.FinalProject.WebApi.Common.Entity;
namespace UnluCo.FinalProject.WebApi.Models
{
    public class Offer : BaseEntity
    {
        [Required]
        public int? Amount { get; set; }
        public int? Percentage { get; set; }
        public virtual Product Product { get; set; }
    }
}
