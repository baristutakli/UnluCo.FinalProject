using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IEmailService
    {
        void SendEmailIntoQueue(MailRequest mailRequest);
    }
}
