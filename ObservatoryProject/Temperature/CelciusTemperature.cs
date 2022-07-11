namespace ObservatoryProject
{
    public class CelciusTemperature : Temperature
    {
        public CelciusTemperature(float value) : base(value)
        {
            // empty constructor
        }

        public override string GetTemperature()
        {
            return value + " °C";
        }
    }
}