using weather.domain.Entity;
using weather.domain.Enum;

namespace weather.db.sqlserver.DTO
{
    public class WeatherDTO
    {
        public int Id { get; set; }
        public string SensorType { get; set; }
        public DateTime Date { get; set; }
        public float Value { get; set; }

        public Weather ConvertToDomainEntity() => new Weather(Id, Date, (SensorType) Enum.Parse(typeof(SensorType), SensorType), Value);
    }
}
