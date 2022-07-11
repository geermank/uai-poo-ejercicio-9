using System.Collections.Generic;

namespace ObservatoryProject
{
    public class UnarySistemPlanet : Planet
    {
        protected Star star;
        protected BaseDistance distanceToStar;
        protected bool goldilocksZone;
        protected bool potentiallyHabitable;

        public UnarySistemPlanet(string name, 
                                  int age,
                                  int mass, 
                                  Temperature temperature, 
                                  List<Satelite> satelites,
                                  Star star,
                                  BaseDistance distanceToStar,
                                  bool goldilocksZone,
                                  bool potentiallyHabitable) : base(name, age, mass, temperature, satelites)
        {
            this.star = star;
            this.distanceToStar = distanceToStar;
            this.goldilocksZone = goldilocksZone;
            this.potentiallyHabitable = potentiallyHabitable;
        }

        public Star Star
        {
            get { return this.star; }
        }

        public BaseDistance DistanceToStar
        {
            get { return this.distanceToStar; }
        }

        public bool GoldilocksZone
        {
            get { return this.goldilocksZone; }
        }

        public bool PotentiallyHabitable
        {
            get { return this.potentiallyHabitable; }
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                "Estrella: " + star.ToString() + "\n" +
                "Distancia a la estrella: " + distanceToStar.GetDistance() + "\n" + 
                "Zona ricitos de oro: " + goldilocksZone.ToString() + "\n" +
                "Es potencialmente habitable: " + potentiallyHabitable.ToString();
        }
    }
}