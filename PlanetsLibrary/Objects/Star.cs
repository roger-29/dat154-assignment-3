using System;

using PlanetsLibrary.Core;

namespace PlanetsLibrary.SpaceObjects {

    public class Star : SpaceObject {

        protected int Radius;

        // E.g. 5800K
        protected int SurfaceTemperature;

        //protected List<Planet> Planets;


        public Star(String name) : base(name) {
            // Planets = new List<Planet> { };

            SurfaceTemperature = 5800;
        }
    }
}
