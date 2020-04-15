using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using WorkerService.Configurations;
using WorkerService.Contracts;

namespace WorkerService.Manager
{
    public class LogManager : ILog
    {
        public LogConfig LogConfig { get; }

        public LogManager(IConfiguration configuration) 
        {
            LogConfig = new LogConfig(configuration);
        }

        private ILogger GetConfiguration()
            => new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File($"{LogConfig.Path}{DateTime.Now.Date:yyyyMMdd}.log")
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
