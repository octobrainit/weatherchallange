using FluentValidation;
using weather.domain.Adapter.v1.Repository.Query;
using weather.domain.Adapter.v1.Service;
using weather.domain.Entity;
using weather.domain.shared.Command;
using weather.domain.shared.Responses;
using weather.shared.logger.Abstraction;

namespace weather.domain.Query.v1.GetWeatherData
{
    public class GetWeatherDataCommandHandler : BaseCommandHandler<GetWeatherDataCommand, EventResponse<List<Weather>>>
    {
        private readonly IRedisService _redisService;
        private readonly IWeatherRepository _weatherRepository;

        public GetWeatherDataCommandHandler(
            IEnumerable<IValidator<GetWeatherDataCommand>> validators, 
            ILogAbstraction logger,
            IWeatherRepository weatherRepository,
            IRedisService redisService
        ) 
        : base(validators, logger)
        {
            _redisService = redisService;
            _weatherRepository = weatherRepository;
        }
        
        public override async Task<EventResponse<List<Weather>>> HandleAsync(GetWeatherDataCommand request)
        {
            var response = await _redisService.GetWeatherByDate(request);

            if (response.Data.Any())
                return response;

            var responsedb = await _weatherRepository.GetWheatherByDate(request);

            if(responsedb.Data.Any())
                await _redisService.PushWeatherOnCache(responsedb.Data);

            return responsedb;
        }
    }
}
