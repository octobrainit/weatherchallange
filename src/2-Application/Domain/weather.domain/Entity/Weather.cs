using weather.domain.Enum;
using weather.domain.shared.Entity;

namespace weather.domain.Entity
{
    public class Weather : EntityAbstractions
    {
        public Weather(int id, DateTime date, SensorType sensor, float value) 
            : base(id)
        {
            Date = date;
            Sensor = sensor;
            Value = value;

            BusinessValidation();
        }
        
        public DateTime Date { get; private set; }
        public SensorType Sensor { get; private set; }
        public float Value { get; private set; }

        public override void BusinessValidation()
        {
            if(DateTime.Now.Date < Date.Date)
                BussinesMessage("Weather date can't be future");
            if(SensorType.Humidity.Equals(Sensor) && Value <= 0 )
                BussinesMessage("Humidity can't be negative");
        }
    }
}
