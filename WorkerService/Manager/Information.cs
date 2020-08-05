using Microsoft.Extensions.Configuration;
using WorkerService.Contracts;

namespace WorkerService.Manager
{
    public class Information : IInformation
    {
        public readonly IConfiguration Configuration;

        public Information(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IEmail Email => new EmailManager(Configuration);

        public ILog Log => new LogManager(Configuration);
    }
}
