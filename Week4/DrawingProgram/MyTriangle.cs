using System;
using SplashKitSDK;
using System.IO;
using MyGame;

namespace ShapeDrawer
{
    public class MyTriangle : Shape
    {
        private float _size; // 等边三角形边长
        private const float HeightFactor = 0.866f; // √3/2

        public float Size
        {
            get => _size;
            set => _size = value > 0 ? value : 100;
        }

        // 默认构造函数
        public MyTriangle() : base(Color.Orange)
        {
            _size = 100;
        }

        // 参数化构造函数
        public MyTriangle(Color color, float size) : base(color)
        {
            _size = size;
        }

        // 顶点计算（以X,Y为中心）
        private (Point2D, Point2D, Point2D) CalculateVertices()
        {
            float halfSize = _size / 2;
            float height = _size * HeightFactor;

            return (
                new Point2D { X = X, Y = Y - height / 2 },          // 顶点
                new Point2D { X = X - halfSize, Y = Y + height/2 }, // 左下
                new Point2D { X = X + halfSize, Y = Y + height/2 }  // 右下
            );
        }

        public override void Draw()
        {
            var (v1, v2, v3) = CalculateVertices();
            SplashKit.FillTriangle(Color, v1.X, v1.Y, v2.X, v2.Y, v3.X, v3.Y);
            
            if (Selected) DrawOutline();
        }

        public override void DrawOutline()
        {
            var (v1, v2, v3) = CalculateVertices();
            int handleSize = 5;
            
            // 三个顶点的选择标记
            SplashKit.FillCircle(Color.Black, v1.X, v1.Y, handleSize);
            SplashKit.FillCircle(Color.Black, v2.X, v2.Y, handleSize);
            SplashKit.FillCircle(Color.Black, v3.X, v3.Y, handleSize);
        }

        public override bool IsAt(Point2D pt)
        {
            var (v1, v2, v3) = CalculateVertices();
            // 正确构造Triangle对象
            Triangle tri = new Triangle
            {
                Points = new[] { v1, v2, v3 }
            };
            return SplashKit.PointInTriangle(pt, tri);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Triangle");
            base.SaveTo(writer);
            writer.WriteLine(_size);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _size = reader.ReadSingle();
        }
    }
}