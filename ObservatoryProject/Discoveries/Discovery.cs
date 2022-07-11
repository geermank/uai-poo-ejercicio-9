using System;

namespace ObservatoryProject
{
    public class Discovery
    {
        private Person discoverer;
        private CelestialBody celestialBody;
        private DateTime date;
        private BaseDistance distanceFromEarth;

        public Discovery(Person discoverer, CelestialBody celestialBody, DateTime date, BaseDistance distanceFromEarth)
        {
            this.discoverer = discoverer;
            this.celestialBody = celestialBody;
            this.date = date;
            this.distanceFromEarth = distanceFromEarth;
        }

        public Person Discoverer
        {
            get { return discoverer; }
        }        

        public CelestialBody CelestialBody
        {
            get { return celestialBody; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        public BaseDistance DistanceFromEarth
        {
            get { return distanceFromEarth; }
        }
    }
}