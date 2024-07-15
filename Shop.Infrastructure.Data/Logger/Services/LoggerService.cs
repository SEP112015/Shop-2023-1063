using Shop.Infrastructure.Logger.Interfaces;

namespace Shop.Infrastructure.Logger.Services
{
    public class LoggerService : ILoggerService
    {
        public void LogError(Exception ex, string message)
        {
            this.LogError(ex, message);
        }

        public void LogInformation(string message)
        {
            this.LogInformation(message);
        }
    }
}
