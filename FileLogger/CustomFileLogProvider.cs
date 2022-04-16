using Microsoft.Extensions.Logging;
/// <summary>
/// provided from class
/// </summary>
namespace FileLogger
{
    public class CustomFileLogProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new CustomFileLogger(categoryName);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}