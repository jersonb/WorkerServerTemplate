using Microsoft.Extensions.Configuration;
namespace WorkerService.Configurations
{
    public static class EmailConfig
    {

        public static string EmailFromName(this IConfiguration config)
             => config.GetValue<string>("Mail:From:Name");


        public static string EmailFromAdress(this IConfiguration config)
            => config.GetValue<string>("Mail:From:Adress");


        public static string EmailToName(this IConfiguration config)
            => config.GetValue<string>("Mail:To:Name");


        public static string EmailToAdress(this IConfiguration config)
            => config.GetValue<string>("Mail:To:Adress");


        public static string EmailHost(this IConfiguration config)
             => config.GetValue<string>("Mail:Host");


        public static int EmailPort(this IConfiguration config)
            => config.GetValue<int>("Mail:Port");


        public static string EmailUsername(this IConfiguration config)
            => config.GetValue<string>("Mail:Username");


        public static string EmailPassword(this IConfiguration config)
            => config.GetValue<string>("Mail:Password");

    }
}
