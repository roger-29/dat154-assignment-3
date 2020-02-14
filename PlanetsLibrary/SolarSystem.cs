using System;
using System.Collections.Generic;


using PlanetsLibrary.Core;
using PlanetsLibrary.SpaceObjects;

namespace PlanetsLibrary {

    class SolarSystem : PlanetarySystem {

        // TODO: Orbit data is accurate, sphere sizes are not

        // TODO: YAML parser?

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
                new Orbit(Mercury, radius: 57910, period: 87.97),
                new Orbit(Venus, radius: 108200, period: 224.7),
                new Orbit(Earth, radius: 149600, period: 365.26),
                new Orbit(Mars, radius: 227940, period: 686.98),
                new Orbit(Jupiter, radius: 778330, period: 4332.71),
                new Orbit(Saturn, radius: 1429400, period: 10759.5),
                new Orbit(Uranus, radius: 2870990, period: 30685.0),
                new Orbit(Neptune, radius: 4504300, period: 60190.0),
                new Orbit(Pluto, radius: 5913520, period: 90550.0),
            });

            return Sun;
        }

        private static Planet Mercury() {
            Planet Mercury = new Planet("Mercury", radius: 10);

            return Mercury;
        }

        private static Planet Venus() {
            Planet Venus = new Planet("Venus", radius: 20);

            return Venus;
        }

        private static Planet Earth() {
            Planet Earth = new Planet("Earth", radius: 20);

            Moon Luna = new Moon("Luna", radius: 4);

            List<Orbit> Orbits = new List<Orbit>() {
                new Orbit(Luna, radius: 384, period: 27.32),
            };

            Earth.AddSatelliteOrbits(Orbits);

            return Earth;
        }

        private static Planet Mars() {
            Planet Mars = new Planet("Mars", radius: 12);

            Moon Phobos = new Moon("Phobos", radius: 3);
            Moon Deimos = new Moon("Deimos", radius: 3);

            Mars.AddSatelliteOrbits(new List<Orbit>() {
                new Orbit(Phobos, radius: 9, period: 0.32),
                new Orbit(Deimos, radius: 23, period: 46023.00)
            });

            return Mars;
        }

        private static Planet Jupiter() {
            Planet Jupiter = new Planet("Jupiter", radius: 12);

            Moon Metis = new Moon("Metis", radius: 3);
            Moon Adrastea = new Moon("Adrastea", radius: 3);
            Moon Amalthea = new Moon("Amalthea", radius: 3);
            Moon Thebe = new Moon("Thebe", radius: 3);
            Moon Io = new Moon("Io", radius: 3);
            Moon Europa = new Moon("Europa", radius: 3);
            Moon Ganymede = new Moon("Ganymede", radius: 3);
            Moon Callisto = new Moon("Callisto", radius: 3);
            Moon Leda = new Moon("Leda", radius: 3);
            Moon Himalia = new Moon("Himalia", radius: 3);
            Moon Lysithea = new Moon("Lysithea", radius: 3);
            Moon Elara = new Moon("Elara", radius: 3);
            Moon Ananke = new Moon("Ananke", radius: 3);
            Moon Carme = new Moon("Carme", radius: 3);
            Moon Pasiphae = new Moon("Pasiphae", radius: 3);
            Moon Sinope = new Moon("Sinope", radius: 3);

            Jupiter.AddSatelliteOrbits(new List<Orbit>() {
                new Orbit(Metis, radius: 128, period: 0.29),
                new Orbit(Adrastea, radius: 129, period: 0.3),
                new Orbit(Amalthea, radius: 181, period: 0.5),
                new Orbit(Thebe, radius: 222, period: 0.67),
                new Orbit(Io, radius: 422, period: 28126.00),
                new Orbit(Europa, radius: 671, period: 20149.00),
                new Orbit(Ganymede, radius: 1070, period: 42186.00),
                new Orbit(Callisto, radius: 1883, period: 16.69),
                new Orbit(Leda, radius: 11094, period: 238.72),
                new Orbit(Himalia, radius: 11480, period: 250.57),
                new Orbit(Lysithea, radius: 11720, period: 259.22),
                new Orbit(Elara, radius: 11737, period: 259.65),
                new Orbit(Ananke, radius: 21200, period: -631.00),
                new Orbit(Carme, radius: 22600, period: -692.00),
                new Orbit(Pasiphae, radius: 23500, period: -735.00),
                new Orbit(Sinope, radius: 23700, period: -758.00),
            });

            return Jupiter;
        }

        private static Planet Saturn() {
            Planet Saturn = new Planet("Saturn", radius: 12);

            // TODO: Moons

            return Saturn;
        }

        private static Planet Uranus() {
            Planet Uranus = new Planet("Uranus", radius: 12);

            // TODO: Moons

            return Uranus;
        }

        private static Planet Neptune() {
            Planet Neptune = new Planet("Neptune", radius: 12);

            // TODO: Moons

            return Neptune;
        }

        private static DwarfPlanet Pluto() {
            DwarfPlanet Pluto = new DwarfPlanet("Pluto", radius: 12);

            Moon Charon = new Moon("Charon", radius: 3);
            Moon Nix = new Moon("Nix", radius: 3);
            Moon Hydra = new Moon("Hydra", radius: 3);

            Pluto.AddSatelliteOrbits(new List<Orbit>() {
                new Orbit(Charon, radius: 20, period: 14397.00),
                new Orbit(Nix, radius: 49, period: 24.86),
                new Orbit(Hydra, radius: 65, period: 38.21)
            });

            return Pluto;
        }
    }
}
