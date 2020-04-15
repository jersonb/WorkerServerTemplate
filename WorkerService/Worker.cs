using Coravel.Invocable;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using WorkerService.Contracts;
using WorkerService.Manager;

namespace WorkerService
{
    public class Worker : IInvocable
    {
        private readonly ILog Loggeding;
        private readonly IEmail Email;

        public Worker(IConfiguration configuration)
        {
            Loggeding = new LogManager(configuration);
            Email = new EmailManager(configuration);
        }

        private bool _retry = true;

        public Task Invoke()
        {
            try
            {
                Loggeding.Info("Init");
                Email.Send("Init");

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                if (_retry)
                {
                    _retry = false;
                    Task.Delay(3000);
                    Loggeding.Info("Retry");
                   return Invoke();
                }
                else
                {
                    Email.Send(ex);
                    Loggeding.Error(ex);
                    return Task.CompletedTask;
                }
            }

        }


    }
}
