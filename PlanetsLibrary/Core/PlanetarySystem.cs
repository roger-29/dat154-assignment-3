using System;
using PlanetsLibrary.SpaceObjects;

namespace PlanetsLibrary.Core {
    public class PlanetarySystem {

        protected SpaceObject CenterObject { get; set; }

        public PlanetarySystem(SpaceObject centerObject) {
            CenterObject = centerObject;
        }

        public void DrawSystemAtTime(int time, double centerX, double centerY) {
            CenterObject.DrawSatellitesRecursively(time, centerX, centerY);
        }
    }
}
