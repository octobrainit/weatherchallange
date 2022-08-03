using Dapper;
using weather.db.sqlserver.Core;
using weather.db.sqlserver.DTO;
using weather.domain.Adapter.v1.Repository.Query;
using weather.domain.Entity;
using weather.domain.Query.v1.GetWeatherData;
using weather.domain.shared.Responses;
using weather.shared.logger.Abstraction;

namespace weather.db.sqlserver.Repository
{
    public class GetWeatherDataRepository : BaseRepository<GetWeatherDataRepository>, IWeatherRepository
    {
        public GetWeatherDataRepository(
            ILogAbstraction logAbstractor, DbSettings connection
        ) : base(logAbstractor, connection)
        { }

        public async Task<EventResponse<List<Weather>>> GetWheatherByDate(GetWeatherDataCommand command)
        {
            return await ExecuteMethod(async (command) => {

                var dateStart = $"{command.Date:yyyy-MM-dd HH:mm:ss}";
                var data = await con.QueryAsync<WeatherDTO>($"Select * from weather NOLOCK  where Date = @date and SensorType = @sensorType ", new { date = dateStart, sensorType = command.SensorType.ToString() });

                var list = data.Select(item => item.ConvertToDomainEntity()).ToList();

                return EventResponse<List<Weather>>.CreateResponse(list);
            }, command);
        }
    }
}
