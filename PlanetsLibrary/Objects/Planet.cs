using System;

using PlanetsLibrary.Core;

namespace PlanetsLibrary.SpaceObjects {

    public class Planet : SpaceObject {

        public Planet(String name, double radius) : base(name, radius) { }

        /*
        public void Draw() {
            // base.Draw();
            Console.Write(" - Planet");
        }
        */
    }
}

