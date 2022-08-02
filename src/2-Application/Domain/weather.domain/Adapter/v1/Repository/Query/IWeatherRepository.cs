using weather.domain.Entity;
using weather.domain.Query.v1.GetWeatherData;
using weather.domain.shared.Responses;

namespace weather.domain.Adapter.v1.Repository.Query
{
    public interface IWeatherRepository
    {
        Task<EventResponse<List<Weather>>> GetWheatherByDate(GetWeatherDataCommand dateTime);

    }
}
