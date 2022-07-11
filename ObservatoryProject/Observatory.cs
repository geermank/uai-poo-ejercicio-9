using ObservatoryProject.Stars;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ObservatoryProject
{
    public class Observatory
    {
        public event delOnDiscoveryCreated OnDiscoveryCreated;

        private List<Discovery> discoveries;
        private List<Constellation> constellations;

        public Observatory()
        {
            discoveries = new List<Discovery>();
            constellations = new List<Constellation>();
        }

        public List<Discovery> Discoveries { get { return discoveries; } }

        public List<Constellation> Constellations {
            get { return constellations; }
        }

        public List<CelestialBody> CelestialBodies
        {
            get
            {
                var results = (from Discovery d in discoveries
                               select d.CelestialBody).ToList();
                return results;
            }
        }

        public List<CelestialBody> Stars
        {
            get
            {
                var stars = (from Discovery d in discoveries
                             where d.CelestialBody is Star
                             select d.CelestialBody).ToList();
                return stars;
            }
        }

        public List<CelestialBody> Planets
        {
            get
            {
                var planets = (from Discovery d in discoveries
                               where d.CelestialBody is Planet
                               select d.CelestialBody).ToList();
                return planets;
            }
        }

        public List<StarColor> StarColors
        {
            get { return new List<StarColor>() {
                    StarColor.YELLOW,
                    StarColor.BLUE,
                    StarColor.ORANGE,
                    StarColor.WHITE,
                    StarColor.RED
                };
            }
        }

        public List<StarType> StarTypes
        {
            get
            {
                return new List<StarType>() {
                    StarType.DWARF,
                    StarType.GIGANTIC
                };
            }
        }

        public List<CelestialBody> FilterPlanetsByName(string planetName)
        {
            return (from d in discoveries
                    where d.CelestialBody is Planet && d.CelestialBody.Name.Contains(planetName)
                    select d.CelestialBody).ToList();
        }

        public List<CelestialBody> FilterPlanetsByStar(Star star)
        {
            return (from d in discoveries
                    where d.CelestialBody is UnarySistemPlanet && (d.CelestialBody as UnarySistemPlanet).Star == star 
                    || d.CelestialBody is BinarySistemPlanet && (d.CelestialBody as BinarySistemPlanet).Star == star || (d.CelestialBody as BinarySistemPlanet).SecondaryStar == star
                    select d.CelestialBody).ToList();
        }

        public List<CelestialBody> FilterPotentiallyHabitablePlanets()
        {
            return (from d in discoveries
                    where d.CelestialBody is UnarySistemPlanet && (d.CelestialBody as UnarySistemPlanet).PotentiallyHabitable
                    select d.CelestialBody).ToList();
        }

        public List<CelestialBody> FilterStarsByColorAndType(StarColor color, StarType type)
        {
            return (from d in discoveries
                    where d.CelestialBody is Star &&
                    (d.CelestialBody as Star).StarType == type &&
                    (d.CelestialBody as Star).StarColor == color
                    select d.CelestialBody).ToList();
        }

        public List<CelestialBody> FilterStarsByTemperature(Temperature temperature)
        {
            return (from d in discoveries
                    where d.CelestialBody is Star &&
                    (d.CelestialBody as Star).Temperature.Equals(temperature)
                    select d.CelestialBody).ToList();
        }

        public List<Star> GetConstellationStars(Constellation constellation)
        {
            return constellation.Stars;
        } 

        public void RegisterNewStarDiscocvery(string name,
                                              int age,
                                              int mass,
                                              Temperature temperature,
                                              int diameter,
                                              StarColor color,
                                              StarType type,
                                              Person person,
                                              DateTime date,
                                              BaseDistance distanceFromEarth,
                                              Constellation constellation)
        {
            Star star = new Star(name, age, mass, temperature, diameter, color, type);
            constellation.AddStar(star);
            RegisterNewDiscovery(person, star, date, distanceFromEarth);
        }

        public void RegisterPlanetDiscovery(string name,
                                            int age,
                                            int mass,
                                            Temperature temperature,
                                            List<Satelite> satelites,
                                            Person person,
                                            DateTime date,
                                            BaseDistance distanceFromEarth)
        {
            Planet planet = new Planet(name, age, mass, temperature, satelites);
            RegisterNewDiscovery(person, planet, date, distanceFromEarth);
        }

        public void RegisterUnarySistemPlanetDiscovery(string name,
                                                       int age,
                                                       int mass,
                                                       Temperature temperature,
                                                       List<Satelite> satelites,
                                                       Star star,
                                                       BaseDistance distanceToStar,
                                                       bool goldilocksZone,
                                                       bool potentiallyHabitable,
                                                       Person person,
                                                       DateTime date,
                                                       BaseDistance distanceFromEarth)
        {
            Planet planet = new UnarySistemPlanet(name, age, mass, temperature, satelites, star, distanceToStar, goldilocksZone, potentiallyHabitable);
            RegisterNewDiscovery(person, planet, date, distanceFromEarth);
        }

        public void RegisterBinarySistemPlanetDiscovery(string name,
                                                       int age,
                                                       int mass,
                                                       Temperature temperature,
                                                       List<Satelite> satelites,
                                                       Star primaryStar,
                                                       BaseDistance distanceToPrimaryStar,
                                                       Star secondaryStar,
                                                       BaseDistance distanceToSecondaryStar,
                                                       bool goldilocksZone,
                                                       bool potentiallyHabitable,
                                                       Person person,
                                                       DateTime date,
                                                       BaseDistance distanceFromEarth)
        {
            Planet planet = new BinarySistemPlanet(name, age, mass, temperature, satelites, primaryStar, distanceToPrimaryStar, secondaryStar, distanceToSecondaryStar, goldilocksZone, potentiallyHabitable);
            RegisterNewDiscovery(person, planet, date, distanceFromEarth);
        }

        private void RegisterNewDiscovery(Person person, CelestialBody celestialBody, DateTime date, BaseDistance distanceFromEarth)
        {
            Discovery discovery = new Discovery(person, celestialBody, date, distanceFromEarth);
            discoveries.Add(discovery);
            OnDiscoveryCreated(discovery);
        }
    }
}
