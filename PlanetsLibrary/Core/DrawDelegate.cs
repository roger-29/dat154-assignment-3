using System;

using Windows.UI.Xaml.Controls;

namespace PlanetsLibrary.Core {
    public delegate void DrawDelegate(SpaceObject spaceObject, Canvas canvas, double x, double y);
}