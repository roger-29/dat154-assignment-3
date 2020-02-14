using System;

using PlanetsLibrary.Core;

namespace PlanetsLibrary.SpaceObjects {

    public class Moon : Planet {

        public Moon(String name, double radius) : base(name, radius) { }

        /*
        public void Draw() {
            base.Draw();
            Console.Write(" - Moon");
        }
        */
    }
}
