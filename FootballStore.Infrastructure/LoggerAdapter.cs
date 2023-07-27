using FootballStore.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace FootballStore.Infrastructure
{
    public sealed class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogError(Exception exeption, string? message, params object[] args)
        {
            _logger.LogError(exeption, message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}
