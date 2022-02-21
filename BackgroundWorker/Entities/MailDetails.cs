using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackgroundWorker.Entities
{
    public class MailDetails
    {
        [JsonConstructor]
        public MailDetails()
        {

        }
        public string Subject { get; set; }

        public string? Sender { get; set; }

        public string? From { get; set; }

        public Encoding? BodyEncoding { get; set; }

        public string Body { get; set; }

        public string[] To { get; }
    }
}
