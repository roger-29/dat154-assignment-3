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


using PlanetsLibrary;
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
            solarSystem = new SolarSystem();

            // Initialize DrawDelegate
            Draw = new DrawDelegate(Objects.DrawSwitch);

            // Start draw loop
            timer = new DispatcherTimer();
            timer.Tick += DispatcherTimerTick;
            timer.Interval = TimeSpan.FromMilliseconds(1000 / 60);
            timer.Start();
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
