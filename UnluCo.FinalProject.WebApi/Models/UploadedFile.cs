using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Common.Entity;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class UploadedFile:BaseEntity
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
