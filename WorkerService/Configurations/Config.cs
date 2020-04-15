using Microsoft.Extensions.Configuration;

namespace WorkerService.Configurations
{
    public abstract class Config
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
