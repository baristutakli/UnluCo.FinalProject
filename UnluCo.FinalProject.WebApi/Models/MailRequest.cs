using System;

namespace UnluCo.FinalProject.WebApi.Models
{
    [Serializable]
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool Status { get; set; }
    }
}
