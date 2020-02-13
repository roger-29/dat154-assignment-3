using System;

namespace PlanetsLibrary.Core {

    public class Orbit {

        public SpaceObject Satellite { get; set; }

        protected double Radius;
        protected double Period;

        public Orbit(SpaceObject satellite, double radius, double period) {
            Satellite = satellite;
            Radius = radius;
            Period = period;
        }

        public ValueTuple<double, double> RelativePositionFromTime(int tick) {
            // Calculate angle from period
            double OrbitProgress = tick / Period;
            double Angle = OrbitProgress * 360 * Math.PI / 180;

            // Calculate position from angle and radius
            double X = Radius * Math.Cos(Angle);
            double Y = Radius * Math.Sin(Angle);

            return (X, Y);
        }

        public ValueTuple<double, double> RelativePositionFromTime(int tick, double aroundX, double aroundY) {
            ValueTuple<double, double> RelativePosition = this.RelativePositionFromTime(tick);

            double X = RelativePosition.Item1 + aroundX;
            double Y = RelativePosition.Item2 + aroundY;

            return (X, Y);
        }
    }
}
