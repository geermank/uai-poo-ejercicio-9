namespace ObservatoryProject
{
    public class CelestialBody
    {
        protected string name;
        protected int age;
        protected int mass;

        public CelestialBody(string name, int age, int mass)
        {
            this.name = name;
            this.age = age;
            this.mass = mass;
        }

        public string Name
        {
            get { return name; }
        }

        public int Age
        {
            get { return age; }
        }

        public int Mass
        {
            get { return mass; }
        }

        public override string ToString()
        {
            return name + "\n" + " Edad: " + age + "\n" + " Masa: " + mass;
        }
    }
}