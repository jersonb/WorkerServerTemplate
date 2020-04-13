using Microsoft.Extensions.Configuration;

namespace WorkerService.Configurations
{
    public class LogConfig : Config
    {
        public LogConfig(IConfiguration configuration) : base(configuration)
        {
        }

        public string Path
            => GetValue("Log:Path");
    }
}
