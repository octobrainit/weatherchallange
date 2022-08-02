namespace weather.shared.logger.Abstraction
{
    public interface ILogAbstraction
    {
        ILogAbstraction LogInformation(string message, string nameOfClass = null);
        ILogAbstraction LogRequest(object data);
         void LogOnConsole();
    }
}
