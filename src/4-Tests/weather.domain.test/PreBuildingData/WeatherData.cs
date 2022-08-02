using weather.domain.Entity;

namespace weather.domain.test.PreBuildingData
{
    public class WeatherData
    {
        public static Weather CreateEntireWeatherHumiditySensor()
        {
            var date = DateTime.Now.AddDays(-1);
            return new Weather(1, date, Enum.SensorType.Humidity, 23);
        }
        public static Weather CreateEntireWeatherTemperatureSensor()
        {
            var date = DateTime.Now.AddDays(-1);
            return new Weather(1, date, Enum.SensorType.Temperature, (float) 45.5);
        }
        public static Weather CreateEntireWeatherRainfallSensor()
        {
            var date = DateTime.Now.AddDays(-1);
            return new Weather(1, date, Enum.SensorType.Rainfall, (float) 97.8);
        }
        public static Weather CreateEntireWeatherRainfallSensorInTheFuture()
        {
            var date = DateTime.Now.AddDays(+1);
            return new Weather(1, date, Enum.SensorType.Rainfall, (float)97.8);
        }
        public static Weather CreateEntireWeatherHumiditySensorNegative()
        {
            var date = DateTime.Now;
            return new Weather(1, date, Enum.SensorType.Humidity, (float)-97.8);
        }
        public static Weather CreateEntireWeatherHumiditySensorNegativeInTheFuture()
        {
            var date = DateTime.Now.AddDays(+1);
            return new Weather(1, date, Enum.SensorType.Humidity, (float)-97.8);
        }
    }
}
