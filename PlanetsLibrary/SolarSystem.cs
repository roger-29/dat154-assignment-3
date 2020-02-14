using System;
using System.Collections.Generic;


using PlanetsLibrary.Core;
using PlanetsLibrary.SpaceObjects;

namespace PlanetsLibrary {

    class SolarSystem : PlanetarySystem {

        public PlanetarySystem System { get; set; }

        public SolarSystem() : base(Sun()) { }

        private static Star Sun() {
            Star Sun = new Star("Sun", radius: 25);

            Planet Mercury = SolarSystem.Mercury();
            Planet Venus = SolarSystem.Venus();
            Planet Mars = SolarSystem.Mars();
            Planet Earth = SolarSystem.Earth();

            Planet Jupiter = SolarSystem.Jupiter();
            Planet Saturn = SolarSystem.Saturn();
            Planet Uranus = SolarSystem.Uranus();
            Planet Neptune = SolarSystem.Neptune();

            DwarfPlanet Pluto = SolarSystem.Pluto();

            Sun.AddSatelliteOrbits(new List<Orbit>() {
                new Orbit(Mercury, radius: 50, period: 100),
                new Orbit(Venus, radius: 100, period: 250),
                new Orbit(Earth, radius: 150, period: 365),
                new Orbit(Mars, radius: 200, period: 650),
                new Orbit(Jupiter, radius: 400, period: 4000),
                new Orbit(Saturn, radius: 500, period: 10000),
                new Orbit(Uranus, radius: 600, period: 30000),
                new Orbit(Neptune, radius: 700, period: 60000),
                new Orbit(Pluto, radius: 800, period: 90000),
            });

            return Sun;
        }

        private static Planet Mercury() {
            return new Planet("Mercury", radius: 10);
        }

        private static Planet Venus() {
            return new Planet("Venus", radius: 20);
        }

        private static Planet Earth() {
            Planet Earth = new Planet("Earth", radius: 20);

            Earth.AddSatelliteOrbit(
                new Orbit(
                    new Moon("Luna", radius: 4), radius: 30, period: 100
                    )
                );

            return Earth;
        }

        private static Planet Mars() {
            Planet Mars = new Planet("Mars", radius: 12);

            Moon Phobos = new Moon("Phobos", radius: 3);
            Moon Deimos = new Moon("Deimos", radius: 3);

            Mars.AddSatelliteOrbits(new List<Orbit>() {
                new Orbit(Phobos, radius: 20, period: 100),
                new Orbit(Deimos, radius: 25, period: 120)
            });

            return Mars;
        }

        private static Planet Jupiter() {
            Planet Jupiter = new Planet("Jupiter", radius: 12);

            return Jupiter;
        }

        private static Planet Saturn() {
            Planet Saturn = new Planet("Saturn", radius: 12);

            return Saturn;
        }

        private static Planet Uranus() {
            Planet Uranus = new Planet("Uranus", radius: 12);

            return Uranus;
        }

        private static Planet Neptune() {
            Planet Neptune = new Planet("Neptune", radius: 12);

            return Neptune;
        }

        private static DwarfPlanet Pluto() {
            DwarfPlanet Pluto = new DwarfPlanet("Pluto", radius: 12);

            return Pluto;
        }
    }
}
