namespace ObservatoryProject
{
    public class TemperatureConverter
    {
        public Temperature ConvertToCelcius(FahrenheitTemperature temperature)
        {
            if (temperature == null)
            {
                return null;
            }

            float celciusValue = (temperature.Value - 32f) * (5f / 9f);
            return new CelciusTemperature(celciusValue);
        }

        public Temperature ConvertToFarenheight(CelciusTemperature temperature)
        {
            if (temperature == null)
            {
                return null;
            }
            float fahrenheitValue = (temperature.Value * (9f / 5f)) + 32f;
            return new FahrenheitTemperature(fahrenheitValue);
        }
    }
}