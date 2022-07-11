using System.Collections.Generic;

namespace ObservatoryProject
{
    public class Planet : CelestialBody
    {
        private Temperature temperature;
        private List<Satelite> satelites;

        public Planet(string name, 
                      int age, 
                      int mass, 
                      Temperature temperature, 
                      List<Satelite> satelites) : base(name, age, mass)
        {
            this.temperature = temperature;
            this.satelites = satelites;
        }

        public Planet(string name,
              int age,
              int mass,
              Temperature temperature) : this(name, age, mass, temperature, new List<Satelite>())
        {
            // empty
        }

        public Temperature Temperature
        {
            get { return temperature; }
        }

        public List<Satelite> Satelites
        {
            get { return satelites; }
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + 
                "Temperatura: " + temperature.GetTemperature() + "\n" + 
                "Cantidad de satelites: " + satelites.Count.ToString();
        }
    }
}