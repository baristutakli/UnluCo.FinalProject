using MimeKit;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IRabbitMQService
    {
        public void Publish(MailRequest mailRequest);
    }
}
