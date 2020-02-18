using System;
using System.Windows;
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

using Windows.System;

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
        private SpaceObject CenterObject;

        private int Depth = 2;
        private new double Scale = 0.0005;

        private double CenterX;
        private double CenterY;

        private DrawDelegate Draw;
        private DispatcherTimer timer;

        public MainPage() {
            this.InitializeComponent();

            this.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(this.Page_KeyDown), handledEventsToo: true);
            CenterX = PlanetariumCanvas.ActualWidth / 2;
            CenterY = PlanetariumCanvas.ActualHeight / 2;

            // Initialize time
            Tick = 0;

            // Initialize solar system
            PlanetarySystem solarSystem = new SolarSystem();
            CenterObject = solarSystem.CenterObject;

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
            DrawOnCanvas(CenterObject, Tick);
        }

        private void DrawOnCanvas(SpaceObject centerObject, int Tick) {
            // Clear before new frame
            PlanetariumCanvas.Children.Clear();
            
            // Draw planetary system
            centerObject.DrawSatellitesRecursively(
                tick: Tick, 
                x: CenterX,
                y: CenterY,
                scale: Scale, 
                maxDepth: Depth, 
                canvas: PlanetariumCanvas, 
                @delegate: Draw
            );
        }

        public void Page_KeyDown(object sender, KeyRoutedEventArgs e) {

            if (timer.IsEnabled) {
                timer.Stop();
            } else {
                timer.Start();
            }

            switch (e.Key) {
                case VirtualKey.Left: Scale *= 2; break;
                case VirtualKey.Right: Scale /= 2; break;
                case VirtualKey.Down: Depth--; break;
                case VirtualKey.Up: Depth++; break;
                case VirtualKey.Space: {
                    if (timer.IsEnabled) {
                        timer.Stop();
                    } else { 
                        timer.Start(); 
                    }
                    break; 
                }
                default: return;
            }
        }

        private void Page_Tapped(object sender, TappedRoutedEventArgs e) {
            if (timer.IsEnabled) {
                timer.Stop();
            } else {
                timer.Start();
            }

            Focus(FocusState.Programmatic);
        }

        private void PlanetariumCanvas_SizeChanged(object sender, SizeChangedEventArgs e) {
            // Get width and height of canvas to determine center
            CenterX = PlanetariumCanvas.ActualWidth / 2;
            CenterY = PlanetariumCanvas.ActualHeight / 2;
        }
    }
}
