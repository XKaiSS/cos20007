using System;
using SplashKitSDK;
using MyGame;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX, _endY;

        // Expose the end point of the line through properties
        public float EndX { get => _endX; set => _endX = value; }
        public float EndY { get => _endY; set => _endY = value; }

        // default constructor
        public MyLine() : base(Color.Red)
        {
            X = 0;
            Y = 0;
            _endX = 50;
            _endY = 50;
        }

        // Constructor with parameters
        public MyLine(Color color, float startX, float startY, float endX, float endY)
            : base(color)
        {
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }

        public override void Draw()
        {
            SplashKit.DrawLine(Color, X, Y, _endX, _endY);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
           // Draw small circles at both ends of the straight line as selected hints
            int handleRadius = 3; 
            SplashKit.FillCircle(Color.Black, X, Y, handleRadius);
            SplashKit.FillCircle(Color.Black, _endX, _endY, handleRadius);
        }

        public override bool IsAt(Point2D pt)
        {
            // 判断点击点是否“接近”直线，这里调用 SplashKit 的 PointOnLine 方法（需要指定容差值，例如 5 像素）
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, _endX, _endY), 5);
        }

         public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_endX);
            writer.WriteLine(_endY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            this._endX = reader.ReadSingle();
            this._endY= reader.ReadSingle();
        }
    }
}
