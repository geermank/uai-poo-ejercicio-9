using ObservatoryProject.Stars;

namespace ObservatoryProject
{
    public class Star : CelestialBody
    {
        private Temperature temperature;
        private int diameter;
        private StarColor starColor;
        private StarType starType;

        public Star(string name, 
                    int age, 
                    int mass, 
                    Temperature temperature, 
                    int diameter, 
                    StarColor color, 
                    StarType type) : base(name, age, mass)
        {
            this.temperature = temperature;
            this.diameter = diameter;
            this.starColor = color;
            this.starType = type;
        }

        public Temperature Temperature
        {
            get { return temperature; }
        }

        public int Diameter
        {
            get { return diameter; }
        }

        public StarType StarType
        {
            get { return starType; }
        }

        public StarColor StarColor
        {
            get { return starColor; }
        }
    }
}