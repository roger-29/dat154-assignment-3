using System;
using System.Collections.Generic;

namespace PlanetsLibrary.Core {

    public class SpaceObject {

        public String Name { get; set; }
        public String Color { get; set; }

        // protected SpaceObject OrbitingAround { get; set; }

        public List<Orbit> SatelliteOrbits { get; set; }

        public SpaceObject(String name) {
            SatelliteOrbits = new List<Orbit> { };

            Name = name;
        }

        public virtual void Draw(double x, double y) {
            Console.WriteLine(Name + " X: " + x + " Y: " + y);
        }

        public void DrawSatellitesRecursively(int tick, double x, double y) {
            this.Draw(x, y);

            foreach (Orbit orbit in this.SatelliteOrbits) {
                ValueTuple<double, double> SatellitePosition = orbit.RelativePositionFromTime(tick, x, y);

                orbit.Satellite.DrawSatellitesRecursively(tick, SatellitePosition.Item1, SatellitePosition.Item2);
            };
        }

        public void AddSatelliteOrbit(Orbit orbit) {
            SatelliteOrbits.Add(orbit);
        }

        public void AddSatelliteOrbits(List<Orbit> orbits) {
            SatelliteOrbits.AddRange(orbits);
        }
    }
}
