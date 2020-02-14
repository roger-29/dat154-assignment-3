using System;

using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;

namespace Graphics {

    public static class Shapes {
        public static void Text(Canvas canvas, string text, int x = 0, int y = 0) {
            TextBlock textBlock = new TextBlock();

            textBlock.Text = text;
            // TODO: Add color

            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);

            canvas.Children.Add(textBlock);
        }

        public static void ObjectDescription(Canvas canvas, string text, int x = 0, int y = 0) {
            // TODO: Refactor

            Brush Stroke = new SolidColorBrush(Colors.Black);
            double StrokeThickness = 3;

            Line slantedLine = new Line();
            Line straightLine = new Line();

            slantedLine.X1 = x;
            slantedLine.Y1 = y;
            slantedLine.X2 = x + 10;
            slantedLine.Y2 = y + 20;

            straightLine.X1 = x + 10;
            straightLine.Y1 = y + 20;
            straightLine.X2 = x + 30;
            straightLine.Y2 = y + 20;

            slantedLine.Stroke = Stroke;
            straightLine.Stroke = Stroke;

            slantedLine.StrokeThickness = StrokeThickness;
            straightLine.StrokeThickness = StrokeThickness;

            // Add first line
            Canvas.SetLeft(slantedLine, 0);
            Canvas.SetTop(slantedLine, 0);

            canvas.Children.Add(slantedLine);

            // Add second line
            Canvas.SetLeft(straightLine, 0);
            Canvas.SetTop(straightLine, 0);

            canvas.Children.Add(straightLine);

            // Add text to canvas
            Text(canvas, text, x + 40, y + 10);
        }

        public static void Circle(Canvas canvas, int x, int y, int radius, Color color) {
            double Width = radius * 2;
            double Height = radius * 2;

            double Left = x - radius;
            double Top = y - radius;

            Ellipse ellipse = new Ellipse();

            ellipse.Width = Width;
            ellipse.Height = Height;

            ellipse.Fill = new SolidColorBrush(color);

            Canvas.SetLeft(ellipse, Left);
            Canvas.SetTop(ellipse, Top);

            canvas.Children.Add(ellipse);
        }

        public static void Rectangle(Canvas canvas, int x, int y, int width, int height) { }
    }

    public static class Constructs {

    }
}