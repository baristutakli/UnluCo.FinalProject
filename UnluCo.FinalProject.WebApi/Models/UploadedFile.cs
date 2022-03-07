using UnluCo.FinalProject.WebApi.Common.Entity;

namespace UnluCo.FinalProject.WebApi.Models
{
    public class UploadedFile : BaseEntity
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
