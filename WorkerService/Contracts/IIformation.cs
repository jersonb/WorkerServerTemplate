namespace WorkerService.Contracts
{
    public interface IInformation
    {
        IEmail Email { get; }
        ILog Log { get; }

    }
}
