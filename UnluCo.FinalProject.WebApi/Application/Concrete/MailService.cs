using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using UnluCo.FinalProject.WebApi.Application.Abstract;
using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Concrete
{
    public class MailService:IEmailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IRabbitMQService _rabbitMQService;
        public MailService(IOptions<MailSettings> mailSettings,IRabbitMQService rabbitMQService)
        {
            _mailSettings = mailSettings.Value;
            _rabbitMQService = rabbitMQService;
        }

        public void  SendEmailIntoQueue(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            try
            {
                _rabbitMQService.Publish(email);
            }
            catch (Exception)
            {

                throw new Exception(message: "Kuyruğa eklenemedi");
            }
            
            
            //using var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            //smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            //await smtp.SendAsync(email);
            //smtp.Disconnect(true);
        }
    }
}
