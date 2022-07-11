namespace ObservatoryProject.Distance
{
    public class DistanceConverter
    {
        private const double ONE_LY_IN_KILOMETERS = 9460730777119;

        public BaseDistance ConvertToKilometers(LightYears distance)
        {
            if (distance == null)
            {
                return new Kilometers(0);
            } else
            {
                double distanceInKilometers = distance.Value * ONE_LY_IN_KILOMETERS;
                return new Kilometers(distanceInKilometers);
            }
        }

        public BaseDistance ConvertToLightYears(Kilometers distance)
        {
            if (distance == null)
            {
                return new LightYears(0);
            } else
            {
                double distanceInKilometers = distance.Value / ONE_LY_IN_KILOMETERS;
                return new LightYears(distanceInKilometers);
            }
        }
    }
}
