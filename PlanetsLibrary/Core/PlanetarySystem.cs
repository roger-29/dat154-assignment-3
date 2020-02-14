using System;
using PlanetsLibrary.SpaceObjects;

namespace PlanetsLibrary.Core {
    public class PlanetarySystem {

        public SpaceObject CenterObject { get; set; }

        public PlanetarySystem(SpaceObject centerObject) {
            CenterObject = centerObject;
        }

        public void DrawSystemAtTime(int time, double centerX, double centerY, DrawDelegate @delegate = null) {
            CenterObject.DrawSatellitesRecursively(time, centerX, centerY, @delegate);
        }
    }
}
