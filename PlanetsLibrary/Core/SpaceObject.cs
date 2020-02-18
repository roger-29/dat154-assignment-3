using System;
using System.Collections.Generic;

using Windows.UI.Xaml.Controls;

namespace PlanetsLibrary.Core {

    public class SpaceObject {

        public String Name { get; set; }
        public String Color { get; set; }

        public double Radius { get; set; }

        public List<Orbit> SatelliteOrbits { get; set; }

        public SpaceObject(String name, double radius) {
            SatelliteOrbits = new List<Orbit> { };

            Name = name;
            Radius = radius;
        }

        public virtual void Draw(double x, double y, double scale, Canvas canvas, DrawDelegate @delegate = null) {
            if (@delegate != null) {
                @delegate.Invoke(this, canvas, x, y);
            }
            else {
                Console.WriteLine(Name + " X: " + x + " Y: " + y);
            }
        }

        public void DrawSatellitesRecursively(int tick, double x, double y, double scale, int maxDepth, Canvas canvas, DrawDelegate @delegate) {
            if (maxDepth < 1) {
                return;
            }

            this.Draw(x, y, scale, canvas, @delegate);

            foreach (Orbit orbit in this.SatelliteOrbits) {
                ValueTuple<double, double> SatellitePosition = orbit.RelativePositionFromTime(tick, x, y, scale);

                orbit.Satellite.DrawSatellitesRecursively(tick, SatellitePosition.Item1, SatellitePosition.Item2, scale, maxDepth - 1, canvas, @delegate);
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
