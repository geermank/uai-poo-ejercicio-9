using System.Collections.Generic;

namespace ObservatoryProject
{
    public class Constellation
    {
        private string name;
        private List<Star> stars;

        public Constellation(string name)
        {
            this.name = name;
            this.stars = new List<Star>();
        }

        public Constellation(string name, List<Star> stars)
        {
            this.name = name;
            this.stars = stars;
        }

        public string Name
        {
            get { return name; }
        }

        public List<Star> Stars
        {
            get { return stars; }
        }

        public void AddStar(Star newStar)
        {
            stars.Add(newStar);
        }

        public override string ToString()
        {
            return name;
        }
    }
}