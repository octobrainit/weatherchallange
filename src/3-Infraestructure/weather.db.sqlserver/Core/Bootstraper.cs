using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using weather.db.sqlserver.Repository;
using weather.domain.Adapter.v1.Repository.Query;

namespace weather.db.sqlserver.Core
{
    public static class Bootstraper
    {
        public static IServiceCollection AddDb(this IServiceCollection service, IConfiguration configuration)
        {
            var connection = configuration.GetSection(nameof(DbSettings)).Get<DbSettings>();
            service.AddSingleton(connection);

            service.AddTransient(typeof(IWeatherRepository), typeof(GetWeatherDataRepository));

            return service;
        }
    }
}
