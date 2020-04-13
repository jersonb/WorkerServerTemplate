using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using WorkerService.Configurations;
using WorkerService.Contracts;

namespace WorkerService.Manager
{
    public class EmailManager : EmailConfig, IEmail
    {
        public EmailManager(IConfiguration configuration) : base(configuration)
        {
        }

        public void Send(string information)
        {
            ConfigureEmail("Tudo Ok!",information);
        }

        public void Send(Exception exception)
        {
            ConfigureEmail("Temos Erros!", $@"Message: {exception.Message}
                                            StackTrace: {exception.StackTrace}
                                            InnerException: {exception.InnerException}
                                            Source: {exception.Source}");
        }

        public void ConfigureEmail(string subject, string bodyText)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(FromName, FromAdress));
                message.To.Add(new MailboxAddress(ToName, ToAdress));
                message.Subject = subject;

                message.Body = new TextPart("plain")
                {
                    Text = bodyText
                };

                using var client = new SmtpClient();
                client.Connect(Host, int.Parse(Port), false);
                client.Authenticate(Username, Password);
                client.Send(message);
                client.Disconnect(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
