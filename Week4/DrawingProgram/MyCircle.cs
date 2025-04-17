using System;
using SplashKitSDK;
using MyGame;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;
        public int Radius { get => _radius; set => _radius = value; }

        // default constructer
        public MyCircle() : base(Color.Blue)
        {
            _radius = 0;
        }

        // Constructor with parameters
        public MyCircle(Color color, int radius) : base(color)
        {
            _radius = radius;
        }

        public override void Draw()
        {

            SplashKit.FillCircle(Color, X, Y, _radius);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            // Draw a black outline 2 pixels larger than the original circle
            SplashKit.DrawCircle(Color.Black, X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            // Detect whether the click point is within the circle
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius));
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(this.Radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            this.Radius = reader.ReadInteger();
        }

    }
}
