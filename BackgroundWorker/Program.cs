using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Application.Concrete;
using UnluCo.FinalProject.WebApi.Models;

namespace BackgroundWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    MailSettings mailSettings = configuration.GetSection("MailSettings").Get<MailSettings>();
                    services.AddSingleton(mailSettings);
                    services.AddScoped<IRabbitMQService, RabbitMQService>();
                    services.AddScoped<IEmailService, MailService>();
                    services.AddHostedService<Worker>();
                });
    }
}
