using UnluCo.FinalProject.WebApi.Models;

namespace UnluCo.FinalProject.WebApi.Application.Abstract
{
    public interface IRabbitMQService
    {
        public void Publish(MailRequest mailRequest);
    }
}
