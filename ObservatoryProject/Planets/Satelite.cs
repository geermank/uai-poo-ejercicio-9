namespace ObservatoryProject
{
    public class Satelite : CelestialBody
    {
        private bool hasTidalLocking;

        public Satelite(string name, int age, int mass) : base(name, age, mass)
        {
            hasTidalLocking = false;
        }

        public Satelite(string name, int age, int mass, bool hasTidalLocking) : base(name, age, mass)
        {
            this.hasTidalLocking = hasTidalLocking;
        }

        public bool HasTidalLocking
        {
            get { return hasTidalLocking; }
        }
    }
}