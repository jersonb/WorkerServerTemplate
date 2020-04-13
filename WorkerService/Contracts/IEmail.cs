using System;

namespace WorkerService.Contracts
{
    public interface IEmail
    {
        void Send(string information);

        void Send(Exception exception);
    }
}
