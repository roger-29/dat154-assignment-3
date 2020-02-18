using System;

using Windows.UI.Xaml.Controls;


using PlanetsLibrary.SpaceObjects;

namespace PlanetsLibrary.Core {
    public class PlanetarySystem {

        public SpaceObject CenterObject { get; set; }

        public PlanetarySystem(SpaceObject centerObject) {
            CenterObject = centerObject;
        }

        public void DrawSystemAtTime(int time, double centerX, double centerY, double scale, int maxDepth, Canvas canvas, DrawDelegate @delegate = null) {
            CenterObject.DrawSatellitesRecursively(time, centerX, centerY, scale, maxDepth, canvas, @delegate);
        }
    }
}
