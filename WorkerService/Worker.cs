using Coravel.Invocable;
using System;
using System.Threading.Tasks;
using WorkerService.Contracts;

namespace WorkerService
{
    public class Worker : IInvocable
    {
        private readonly ILog Loggeding;
        private readonly IEmail Email;

        public Worker(IInformation information)
        {
            Loggeding = information.Log;
            Email = information.Email;
        }

        private bool _retry = true;

        public Task Invoke()
        {
            try
            {
                Loggeding.Info("Init");
                Email.Send("");
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
                    Loggeding.Error(ex);
                    return Task.CompletedTask;
                }
            }

        }


    }
}
