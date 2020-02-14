using System;

using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;

using PlanetsLibrary.Core;
using PlanetsLibrary.SpaceObjects;

namespace Graphics {

    public static class Objects {

        public static void DrawSwitch(SpaceObject spaceObject, Canvas canvas, double x, double y) {
            switch (spaceObject) {
                case Star c: DrawStar(c, canvas, x, y); break;
                case Moon c: DrawMoon(c, canvas, x, y); break;
                case DwarfPlanet c: DrawDwarfPlanet(c, canvas, x, y); break;
                case Planet c: DrawPlanet(c, canvas, x, y); break;
                case Comet c: DrawComet(c, canvas, x, y); break;
                case Asteroid c: DrawAsteroid(c, canvas, x, y); break;

                default: DrawSpaceObject(spaceObject, canvas, x, y); break;
            }
        }

        public static void DrawSpaceObject(SpaceObject spaceObject, Canvas canvas, double x, double y) {
            Color color = Color.FromArgb(255, 127, 127, 127);
        }

        public static void DrawStar(Star star, Canvas canvas, double x, double y) {
            Color color = Color.FromArgb(255, 240, 80, 80);

            // Draw base shape
            Shapes.Circle(canvas, (int) x, (int) y, (int) Math.Round(star.Radius), color);
            Shapes.ObjectDescription(canvas, star.Name, (int)x, (int)y);
        }

        public static void DrawPlanet(Planet planet, Canvas canvas, double x, double y) {
            Color color = Color.FromArgb(255, 127, 127, 127);

            // Draw base shape
            Shapes.Circle(canvas, (int) x, (int) y, (int) Math.Round(planet.Radius), color);
            Shapes.ObjectDescription(canvas, planet.Name, (int)x, (int)y);
        }

        public static void DrawMoon(Moon moon, Canvas canvas, double x, double y) {
            Color color = Color.FromArgb(255, 127, 127, 127);

            // Draw base shape
            Shapes.Circle(canvas, (int)x, (int)y, (int)Math.Round(moon.Radius), color);
            Shapes.ObjectDescription(canvas, moon.Name, (int)x, (int)y);
        }
        
        public static void DrawAsteroid(Asteroid asteroid, Canvas canvas, double x, double y) { }
        
        public static void DrawComet(Comet comet, Canvas canvas, double x, double y) { }
        
        public static void DrawDwarfPlanet(DwarfPlanet dwarfPlanet, Canvas canvas, double x, double y) {
            Color color = Color.FromArgb(255, 127, 127, 127);

            // Draw base shape
            Shapes.Circle(canvas, (int)x, (int)y, (int)Math.Round(dwarfPlanet.Radius), color);
            Shapes.ObjectDescription(canvas, dwarfPlanet.Name, (int)x, (int)y);
        }
    }
}