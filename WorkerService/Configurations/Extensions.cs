using Microsoft.Extensions.Configuration;

namespace WorkerService.Configurations
{
    public static class Extensions
    {
        public static string GetLogPath(this IConfiguration configuration)
            => configuration.GetValue<string>("Log:Path");

        public static string GetNameSender(this IConfiguration config)
             => config.GetValue<string>("Mail:From:Name");


        public static string GetEmailSender(this IConfiguration config)
            => config.GetValue<string>("Mail:From:Adress");


        public static string GetEmailDestinatary(this IConfiguration config)
            => config.GetValue<string>("Mail:To:Name");


        public static string GetEmailAdressToSend(this IConfiguration config)
            => config.GetValue<string>("Mail:To:Adress");


        public static string GetEmailHost(this IConfiguration config)
             => config.GetValue<string>("Mail:Host");


        public static int GetEmailPort(this IConfiguration config)
            => config.GetValue<int>("Mail:Port");


        public static string GetEmailUsername(this IConfiguration config)
            => config.GetValue<string>("Mail:Username");


        public static string GetEmailPassword(this IConfiguration config)
            => config.GetValue<string>("Mail:Password");

    }
}
