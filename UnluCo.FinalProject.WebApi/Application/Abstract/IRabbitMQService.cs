using MimeKit;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IRabbitMQService
    {
        public void Publish(MimeMessage email);
    }
}
