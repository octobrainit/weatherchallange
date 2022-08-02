using System.ComponentModel;

namespace weather.domain.Enum
{
    public enum SensorType
    {
        [Description("Temperature")]
        Temperature,
        [Description("Humidity")]
        Humidity,
        [Description("Rainfall")]
        Rainfall
    }
}
