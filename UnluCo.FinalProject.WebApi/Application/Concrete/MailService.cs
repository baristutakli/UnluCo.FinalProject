using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class MailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IRabbitMQService _rabbitMQService;
        public MailService(IOptions<MailSettings> mailSettings, IRabbitMQService rabbitMQService)
        {
            _mailSettings = mailSettings.Value;
            _rabbitMQService = rabbitMQService;
        }

        // Call RabitMQService and publish 
        public void SendEmailIntoQueue(MailRequest mailRequest)
        {
            var mail = new MailMessage();
            mail.Sender = new MailAddress(_mailSettings.Mail, "s");
            mail.To.Add(new MailAddress(mailRequest.ToEmail, "ss"));
            mail.Subject = mailRequest.Subject;
            mail.Body = mailRequest.Body;
            mail.From = new MailAddress(_mailSettings.Mail, "ss");
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            try
            {
                _rabbitMQService.Publish(mailRequest);
            }
            catch (Exception e)
            {

                throw new Exception(message: e.Message);
            }

        }


    }
}
