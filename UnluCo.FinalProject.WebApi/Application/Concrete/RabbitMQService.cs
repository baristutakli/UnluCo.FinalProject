using Microsoft.Extensions.Configuration;
using MimeKit;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;

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

        public void Publish(MimeMessage email)
        {

            IConnection connection = _factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: "Mails",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(email));

            channel.BasicPublish(exchange: "",
                 routingKey: "Mails",
                 basicProperties: null,
                 body: body);

        }
    }
}
