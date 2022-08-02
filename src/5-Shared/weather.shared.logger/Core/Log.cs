using Newtonsoft.Json;
using Serilog;
using weather.shared.logger.Abstraction;

namespace weather.shared.logger.Core
{
    public class Log : ILogAbstraction
    {
        public List<string> Logs { get; }
        public ILogger _log { get; }

        public Log(ILogger logger)
        {
            _log = logger;
            Logs = new List<string>();
        }

        public ILogAbstraction LogInformation( string message, string nameOfClass = null)
        {
            Logs.Add(message);
            return this;
        }

        public ILogAbstraction LogRequest(object data)
        {
            Logs.Add($"Data Request ({data.GetType().FullName}) : \n {JsonConvert.SerializeObject(data, Formatting.Indented)}");
            return this;
        }

        public void LogOnConsole()
        {
            _log.Warning(String.Join(";\n", Logs));
        }
    }
}
