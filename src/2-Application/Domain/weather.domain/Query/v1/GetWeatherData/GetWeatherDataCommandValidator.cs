using FluentValidation;
using weather.domain.Enum;

namespace weather.domain.Query.v1.GetWeatherData
{
    public class GetWeatherDataCommandValidator : AbstractValidator<GetWeatherDataCommand>
    {
        public GetWeatherDataCommandValidator()
        {
            RuleFor(data => data.DeviceId).NotNull().NotEmpty().NotEqual("string");
            RuleFor(data => data.Date).NotNull().NotEmpty();
            RuleFor(data => data).NotNull().NotEmpty().Must((request) =>
            {
               return System.Enum.GetValues<SensorType>().Contains(request.SensorType);

            }).WithMessage("Sensor is invalid");
        }
    }
}
