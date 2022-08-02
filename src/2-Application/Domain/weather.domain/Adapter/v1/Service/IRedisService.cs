using weather.domain.Entity;
using weather.domain.Query.v1.GetWeatherData;
using weather.domain.shared.Responses;

namespace weather.domain.Adapter.v1.Service
{
    public interface IRedisService
    {
        Task<EventResponse<List<Weather>>> GetWeatherByDate(GetWeatherDataCommand data);
        Task<EventResponse<Weather>> PushWeatherOnCache(List<Weather> data);
    }
}
