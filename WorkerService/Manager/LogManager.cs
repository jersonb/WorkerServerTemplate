using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using WorkerService.Configurations;
using WorkerService.Contracts;

namespace WorkerService.Manager
{
    public class LogManager : ILog
    {
        private readonly string Path = null;

        public LogManager(IConfiguration configuration)
        {
            Path = configuration.GetLogPath();
        }

        private ILogger GetConfiguration()
            => new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File($"{Path}{DateTime.Now.Date:yyyyMMdd}.log")
                    .CreateLogger();

        public void Error(Exception exception)
        {
            Log.Logger = GetConfiguration();

            Log.Error(exception, $@"Message: {exception.Message}
                                   StackTrace: {exception.StackTrace}
                                   InnerException: {exception.InnerException}
                                   Source: {exception.Source}");
            Log.CloseAndFlush();
        }

        public void Info(string info)
        {
            Log.Logger = GetConfiguration();

            Log.Information(info);

            Log.CloseAndFlush();
        }

    }
}
