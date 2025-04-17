using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        // default constructor
        private int _width, _height;
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        // Default constructor 
        public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 100, 100)
        {
        }

        // Constructor with parameters
        public MyRectangle(Color color, float x, float y, int width, int height)
            : base(color)
        {
            X = x;
            Y = y;
            _width = width;
            _height = height;
        }

        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, _width, _height);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            // Draw the border in black
            int padding = 5; // 可调整的边框宽度
            SplashKit.DrawRectangle(Color.Black, X - padding, Y - padding, _width + 2 * padding, _height + 2 * padding);
        }

        public override bool IsAt(Point2D pt)
        {
            // Check if the click point is within the rectangle
            return pt.X >= X && pt.X <= X + _width &&
                   pt.Y >= Y && pt.Y <= Y + _height;
        }
    }
}
