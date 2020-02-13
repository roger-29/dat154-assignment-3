using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Xunit;
using Xunit.Abstractions;


using PlanetsLibrary.Core;
using PlanetsLibrary.SpaceObjects;


namespace PlanetsLibraryTests {

    public class SolarSystem {

        public SolarSystem(ITestOutputHelper output) {
            var converter = new Converter(output);
            Console.SetOut(converter);

        }

        private class Converter : TextWriter {
            ITestOutputHelper _output;
            public Converter(ITestOutputHelper output) {
                _output = output;
            }
            public override Encoding Encoding {
                get { return Encoding.UTF8; }
            }
            public override void WriteLine(string message) {
                _output.WriteLine(message);
            }
            public override void WriteLine(string format, params object[] args) {
                _output.WriteLine(format, args);
            }
        }

        [Fact]
        public void TestSetupSolarSystem() {

            Star Sun = new Star("Sun");

            PlanetarySystem SolarSystem = new PlanetarySystem(Sun);


            List<Orbit> Planets = new List<Orbit>() {
                new Orbit(new Planet("Yup"), 0.1, 0.1),
                new Orbit(new Planet("skj"), 0.1, 0.1)
            };

            Sun.AddSatelliteOrbits(Planets);

            SolarSystem.DrawSystemAtTime(0, 0.0, 0.0);
        }
    }
}
