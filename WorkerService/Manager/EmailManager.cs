using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using WorkerService.Configurations;
using WorkerService.Contracts;

namespace WorkerService.Manager
{
    public class EmailManager : IEmail
    {
        private readonly  IConfiguration config;

        public EmailManager(IConfiguration configuration)
        {
            config = configuration;
        }

        private void ConfigureEmail(string subject, string bodyText)
        {
            var message = new MimeMessage();
            message.From.Add(From);
            message.To.Add(To);
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = bodyText
            };

            using var client = new SmtpClient();
            client.Connect(config.GetEmailHost(), config.GetEmailPort(), false);
            client.Authenticate(config.GetEmailUsername(), config.GetEmailPassword());
            client.Send(message);
            client.Disconnect(true);

        }

        private MailboxAddress To
            => new MailboxAddress(config.GetEmailDestinatary(), config.GetEmailAdressToSend());

        private MailboxAddress From
            => new MailboxAddress(config.GetNameSender(), config.GetEmailSender());

        public void Send(string information)
        {
           // ConfigureEmail("Tudo Ok!", information);
        }

        public void Send(Exception exception)
        {
            ConfigureEmail("Temos Erros!", $@"Message: {exception.Message}
                                            StackTrace: {exception.StackTrace}
                                            InnerException: {exception.InnerException}
                                            Source: {exception.Source}");
        }

        
    }
}
