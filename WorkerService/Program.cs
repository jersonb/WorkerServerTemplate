using Coravel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace WorkerService
{
    public static class Program
    {
        private static (int Hour, int Minute) _schedule;

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                .UseWindowsService()
                .Build();

            host.Services.UseScheduler(scheduler =>
               {
                   scheduler.Schedule<Worker>()
                            .DailyAt(_schedule.Hour,_schedule.Minute)
                            .Zoned(TimeZoneInfo.Local)
                            .Weekday();

               }).OnError(ex => throw ex);

            host.Run();
            host.Dispose();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.Sources.Clear();

                    var env = hostingContext.HostingEnvironment;

                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    config.AddEnvironmentVariables();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScheduler();

                    GetSchedule(hostContext.Configuration);

                    services.AddSingleton(hostContext.Configuration);

                    services.AddTransient<Worker>();
                });

        private static void GetSchedule(IConfiguration configuration) 
        {
            var hour = int.Parse(configuration["Schedule:Hour"]);
            var minute = int.Parse(configuration["Schedule:Minute"]);

            _schedule = (hour, minute);
        }
    }
}
