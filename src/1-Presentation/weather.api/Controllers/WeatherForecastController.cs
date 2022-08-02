using MediatR;
using Microsoft.AspNetCore.Mvc;
using weather.api.Core;
using weather.domain.Entity;
using weather.domain.Enum;
using weather.domain.Query.v1.GetWeatherData;
using weather.domain.shared.Responses;

namespace weather.api.Controllers
{
    [ApiController]
    [Route("api/v1/device")]
    public class WeatherForecastController : BaseController<WeatherForecastController>
    {
        private readonly IMediator _mediatR;

        public WeatherForecastController(IMediator mediator) {
            _mediatR = mediator;
        }

        [HttpGet(Name = "{devideId}/data/{date}/{sensor}")]
        public async Task<EventResponse<List<Weather>>> Get(string deviceId, DateTime date, SensorType sensor )
        {

            var command = new GetWeatherDataCommand(date, sensor, deviceId);
            
            var response = await ExecuteHandler(async(command) => {
                return await _mediatR.Send(command);
            }, command);

            return response;
        }
    }
}