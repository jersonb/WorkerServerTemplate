using Microsoft.Extensions.Configuration;
using WorkerService.Contracts;

namespace WorkerService.Configurations
{
    public abstract class Config : IConfig
    {
        public IConfiguration Configuration { get; }

        protected Config(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GetValue(string section)
            => Configuration[section];
    }
}
