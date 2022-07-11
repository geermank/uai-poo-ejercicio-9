namespace ObservatoryProject
{
    public class FahrenheitTemperature : Temperature
    {
        public FahrenheitTemperature(float value) : base(value)
        {
            // empty constructor
        }

        public override string GetTemperature()
        {
            return value + " °F";
        }
    }
}