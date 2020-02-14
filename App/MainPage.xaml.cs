using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using PlanetsLibrary.Core;
using Graphics;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {

        private int Tick;
        private PlanetarySystem solarSystem;

        private DrawDelegate Draw;

        private const double CENTER_X = 0.0;
        private const double CENTER_Y = 0.0;


        public MainPage() {
            this.InitializeComponent();

            // Initialize time
            Tick = 0;

            // Initialize solar system
            SpaceObject SpaceObject = new SpaceObject("Test");

            // Initialize DrawDelegate
            Draw = new DrawDelegate(Objects.DrawSwitch);

            // Start draw loop
            
        }

        public void DrawOnCanvas(PlanetarySystem planetarySystem) {
            // PlanetariumCanvas

            planetarySystem.DrawSystemAtTime(Tick, CENTER_X, CENTER_Y, Draw);
        }
    }
}
