using Microsoft.Extensions.DependencyInjection;
using weather.shared.logger.Abstraction;

namespace weather.shared.logger.Core
{
    public static class Bootstraper
    {
        public static IServiceCollection AddLogger(this IServiceCollection service)
        {
            service.AddTransient(typeof(ILogAbstraction), typeof(Log));
            return service;
        }
    }
}
