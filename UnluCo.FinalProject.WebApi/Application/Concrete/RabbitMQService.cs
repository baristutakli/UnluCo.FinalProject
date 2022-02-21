using Microsoft.Extensions.Configuration;
using MimeKit;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Common.Tools;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class RabbitMQService : IRabbitMQService
    {
        private IConfiguration _configuration;
        public ConnectionFactory _factory { get; private set; }
        public RabbitMQService(IConfiguration configuration)
        {
            _configuration = configuration;
            _factory = new ConnectionFactory() { Uri = new Uri(_configuration.GetSection("RabbitMqSettings:URL").Value) };
        }

        public void Publish(MailRequest mailRequest)
        {

            IConnection connection = _factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: "Mails",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mailRequest,formatting:Formatting.Indented));

            channel.BasicPublish(exchange: "",
                 routingKey: "Mails",
                 basicProperties: null,
                 body: body);

        }
    }
}
