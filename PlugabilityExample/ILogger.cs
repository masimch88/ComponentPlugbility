namespace PlugabilityExample.Tests
{
    public interface ILogger
    {
		void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }

        public void Log(string message)
        {
            message = $"[{DateTime.UtcNow:yyyy/MM/dd HH:mm:ss.fff}] {message}";
            File.AppendAllLines(_path, new[] { message });
        }
    }

}