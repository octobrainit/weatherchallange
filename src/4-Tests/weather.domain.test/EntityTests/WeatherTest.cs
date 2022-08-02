using weather.domain.test.PreBuildingData;

namespace weather.domain.test.EntityTests
{
    public class WeatherTest
    {
        [Fact]
        public void Is_Valid_Entity()
        {
            var rainfallSensor = WeatherData.CreateEntireWeatherRainfallSensor();
            var temperatureSensor = WeatherData.CreateEntireWeatherTemperatureSensor();
            var humiditySensor = WeatherData.CreateEntireWeatherHumiditySensor();

            Assert.True(rainfallSensor.IsValid);
            Assert.True(temperatureSensor.IsValid);
            Assert.True(humiditySensor.IsValid);
        }

        [Fact]
        public void Create_Weather_In_the_Future_Is_Invalid()
        {
            var rainfall = WeatherData.CreateEntireWeatherRainfallSensorInTheFuture();

            Assert.False(rainfall.IsValid);
            Assert.True(rainfall.Messages.Count == 1);
            Assert.True(rainfall.Messages[0].Equals("Weather date can't be future"));
        }

        [Fact]
        public void Create_Weather_Humidity_Sensor_Negative_Is_Invalid()
        {
            var humidity = WeatherData.CreateEntireWeatherHumiditySensorNegative();

            Assert.False(humidity.IsValid);
            Assert.True(humidity.Messages.Count == 1);
            Assert.True(humidity.Messages[0].Equals("Humidity can't be negative"));
        }
        [Fact]
        public void Create_Weather_Humidity_Sensor_Negative_In_The_Future_Is_Invalid()
        {
            var humidity = WeatherData.CreateEntireWeatherHumiditySensorNegativeInTheFuture();

            Assert.False(humidity.IsValid);
            Assert.True(humidity.Messages.Count == 2);
            Assert.True(humidity.Messages.Contains("Humidity can't be negative"));
            Assert.True(humidity.Messages.Contains("Weather date can't be future"));
        }
    }
}
