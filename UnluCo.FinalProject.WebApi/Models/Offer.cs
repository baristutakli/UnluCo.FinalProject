using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Common.Entity;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class Offer:BaseEntity
    {

        public int? Amount { get; set; }
        public int? Percentage { get; set; }
        public virtual Product Product { get; set; }
    }
}
