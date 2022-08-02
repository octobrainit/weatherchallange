using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using weather.cache.redis.Service;
using weather.domain.Adapter.v1.Service;

namespace weather.cache.redis.Core
{
    public static class Bootstraper
    {
        public static IServiceCollection AddRedis(this IServiceCollection service, IConfiguration configuration)
        {
            var connection = configuration.GetSection(nameof(RedisSettings)).Get<RedisSettings>();
            service.AddSingleton(connection);
            var multiplexer = ConnectionMultiplexer.Connect(connection.Connection);
            
            service.AddSingleton<IConnectionMultiplexer>(multiplexer);
            service.AddTransient<IRedisService, CacheService>();


            return service;
        }
    }
}
