using System.Collections.Generic;

namespace ObservatoryProject
{
    public class BinarySistemPlanet : UnarySistemPlanet
    {
        private Star secondaryStar;
        private BaseDistance distanceToSecondaryStar;

        public BinarySistemPlanet(string name,
                                  int age,
                                  int mass,
                                  Temperature temperature,
                                  List<Satelite> satelites,
                                  Star primaryStar,
                                  BaseDistance distanceToPrimaryStar,
                                  Star secondaryStar,
                                  BaseDistance distanceToSecondaryStar,
                                  bool goldilocksZone,
                                  bool potentiallyHabitable) : base(name, age, mass, temperature, satelites, primaryStar, distanceToPrimaryStar, goldilocksZone, potentiallyHabitable)
        {
            this.secondaryStar = secondaryStar;
            this.distanceToSecondaryStar = distanceToSecondaryStar;
        }

        public Star SecondaryStar
        {
            get { return secondaryStar; }
        }

        public BaseDistance DistanceToSecondaryStar
        {
            get { return distanceToSecondaryStar; }
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                "Estrella secundaria: " + secondaryStar.ToString() + "\n" +
                "Distancia a estrella secundaria: " + distanceToSecondaryStar.GetDistance();
        }
    }
}