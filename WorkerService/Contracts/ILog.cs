using System;

namespace WorkerService.Contracts
{
    public interface ILog
    {
        void Info(string info);

        void Error(Exception exception);
    }
}
