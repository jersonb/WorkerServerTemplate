using Microsoft.Extensions.Configuration;

namespace WorkerService.Contracts
{
    public interface IConfig
    {
        public IConfiguration Configuration { get; }
    }
}
