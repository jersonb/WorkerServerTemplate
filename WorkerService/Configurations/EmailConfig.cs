using Microsoft.Extensions.Configuration;

namespace WorkerService.Configurations
{
    public class EmailConfig : Config
    {
        public EmailConfig(IConfiguration configuration) : base(configuration)
        {
        }

        public string FromName
             => GetValue("Mail:From:Name");

        public string FromAdress
            => GetValue("Mail:From:Adress");

        public string ToName
            => GetValue("Mail:To:Name");

        public string ToAdress
            => GetValue("Mail:To:Adress");

        public string Host
             => GetValue("Mail:Host");

        public string Port
            => GetValue("Mail:Port");

        public string Username
            => GetValue("Mail:Username");

        public string Password
            => GetValue("Mail:Password");


    }
}
