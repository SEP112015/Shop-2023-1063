namespace Shop.Infrastructure.Logger.Interfaces
{
    public interface ILoggerService<T>
    {
        void LogError(string message, string exception);
        void LogInformation(string message);
    }
}
