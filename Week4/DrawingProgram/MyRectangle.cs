using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        // 只有矩形需要的字段和属性
        private int _width, _height;
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }

        // 默认构造函数（可以使用 this 调用下一个构造函数，并设置默认颜色、大小、位置等）
        public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 100, 100)
        {
        }

        // 带参数构造函数
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
            // 这里设定一个简单的轮廓绘制：以黑色绘制边框
            int padding = 5; // 可调整的边框宽度
            SplashKit.DrawRectangle(Color.Black, X - padding, Y - padding, _width + 2 * padding, _height + 2 * padding);
        }

        public override bool IsAt(Point2D pt)
        {
            // 检查点击点是否在矩形内
            return pt.X >= X && pt.X <= X + _width &&
                   pt.Y >= Y && pt.Y <= Y + _height;
        }
    }
}
