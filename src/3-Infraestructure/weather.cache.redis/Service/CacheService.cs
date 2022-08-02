﻿using Newtonsoft.Json;
using StackExchange.Redis;
using weather.cache.redis.Core;
using weather.domain.Adapter.v1.Service;
using weather.domain.Entity;
using weather.domain.Query.v1.GetWeatherData;
using weather.domain.shared.Responses;

namespace weather.cache.redis.Service
{
    public class CacheService : IRedisService
    {
        private readonly RedisSettings _redisSettings;
        private readonly IConnectionMultiplexer _redis;

        public CacheService(
            RedisSettings redisSettings,
            IConnectionMultiplexer redis
        )
        {
            _redisSettings = redisSettings;
            _redis = redis;
        }
        public async Task<EventResponse<List<Weather>>> GetWeatherByDate(GetWeatherDataCommand data)
        {
            var db = _redis.GetDatabase();
            var key = $"{data.Date:yyyy-MM-dd HH:mm:ss}_{data.SensorType}";
            var response = await db.StringGetAsync(key);
            if (response.HasValue)
                return EventResponse<List<Weather>>.CreateResponse(JsonConvert.DeserializeObject<List<Weather>>(response));

            return EventResponse<List<Weather>>.CreateResponse(new List<Weather>());

        }

        public async Task<EventResponse<Weather>> PushWeatherOnCache(List<Weather> data)
        {
            var db = _redis.GetDatabase();

            foreach (Weather weather in data)
            {
                var dataConverted = JsonConvert.SerializeObject(data);
                await db.StringSetAsync($"{weather.Date.ToString("yyyy-MM-dd HH:mm:ss")}_{weather.Sensor}", dataConverted);
            }

            return EventResponse<Weather>.CreateResponse(null);
        }
    }
}
