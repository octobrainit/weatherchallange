using weather.domain.Entity;
using weather.domain.Enum;
using weather.domain.shared.Command;

namespace weather.domain.Query.v1.GetWeatherData
{
    public class GetWeatherDataCommand : BaseCommand<GetWeatherDataCommand, List<Weather>>
    {
        public GetWeatherDataCommand(DateTime date, SensorType sensor, string deviceId) : base() {
            Date = date;
            SensorType = sensor;
            DeviceId = deviceId;
        }

        public DateTime Date { get; set; }
        public SensorType SensorType { get; set; }
        public string DeviceId { get; set; }
    }
}
