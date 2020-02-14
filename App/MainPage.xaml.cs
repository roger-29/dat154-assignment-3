using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;


using PlanetsLibrary.Core;
using PlanetsLibrary.SpaceObjects;

using Graphics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page {


        private int Tick;
        private PlanetarySystem solarSystem;

        private DrawDelegate Draw;
        private DispatcherTimer timer;

        public MainPage() {
            this.InitializeComponent();

            // Initialize time
            Tick = 0;

            // Initialize solar system
            solarSystem = InitializeSolarSystem();

            // Initialize DrawDelegate
            Draw = new DrawDelegate(Objects.DrawSwitch);

            // Start draw loop
            timer = new DispatcherTimer();
            timer.Tick += DispatcherTimerTick;
            timer.Interval = TimeSpan.FromMilliseconds(1000 / 60);
            timer.Start();
        }

        private PlanetarySystem InitializeSolarSystem() {
            Star sun = new Star("Sun", 25);

            Planet Mercury = new Planet("Mercury", radius: 10);
            Planet Venus = new Planet("Venus", radius: 20);
            Planet Earth = new Planet("Earth", radius: 20);
            Planet Mars = new Planet("Mars", radius: 12);

            // AsteroidBelt

            Planet Jupiter = new Planet("Jupiter", radius: 12);
            Planet Saturn = new Planet("Saturn", radius: 12);
            Planet Uranus = new Planet("Uranus", radius: 12);
            Planet Neptune = new Planet("Neptune", radius: 12);

            DwarfPlanet Pluto = new DwarfPlanet("Pluto", radius: 12);

            Earth.AddSatelliteOrbit(
                new Orbit(
                    new Moon("Luna", radius: 4), radius: 30, period: 100
                    )
                );

            sun.AddSatelliteOrbits(new List<Orbit>() {
                new Orbit(Mercury, radius: 50, period: 100),
                new Orbit(Venus, radius: 100, period: 250),
                new Orbit(Earth, radius: 150, period: 365),
                new Orbit(Mars, radius: 200, period: 650),
                new Orbit(Jupiter, radius: 400, period: 4000),
                new Orbit(Saturn, radius: 500, period: 10000),
                new Orbit(Uranus, radius: 600, period: 30000),
                new Orbit(Neptune, radius: 700, period: 60000),
                new Orbit(Pluto, radius: 800, period: 90000),
            });

            return new PlanetarySystem(sun);
        }

        private void DispatcherTimerTick(object sender, object e) {
            // Increment ticker upon timer fire
            Tick++;

            // Draw solar system on canvas
            DrawOnCanvas(solarSystem, Tick);
        }

        private void DrawOnCanvas(PlanetarySystem planetarySystem, int Tick) {
            // Clear before new frame
            PlanetariumCanvas.Children.Clear();

            // Get width and height of canvas to determine center
            double Width = PlanetariumCanvas.ActualWidth;
            double Height = PlanetariumCanvas.ActualHeight;

            // Draw planetary system
            planetarySystem.DrawSystemAtTime(Tick, Width / 2, Height / 2, PlanetariumCanvas, Draw);
        }
    }
}
