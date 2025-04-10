using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX, _endY;

        // 通过属性暴露直线终点
        public float EndX { get => _endX; set => _endX = value; }
        public float EndY { get => _endY; set => _endY = value; }

        // 默认构造函数：设置默认颜色为红色，以及默认起点(0,0)和终点(50,50)（你可以根据需求调整）
        public MyLine() : base(Color.Red)
        {
            X = 0;
            Y = 0;
            _endX = 50;
            _endY = 50;
        }

        // 带参数构造函数：传入颜色、起点、终点
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
            // 绘制直线两端的小圆作为选中的提示
            int handleRadius = 3; 
            SplashKit.FillCircle(Color.Black, X, Y, handleRadius);
            SplashKit.FillCircle(Color.Black, _endX, _endY, handleRadius);
        }

        public override bool IsAt(Point2D pt)
        {
            // 判断点击点是否“接近”直线，这里调用 SplashKit 的 PointOnLine 方法（需要指定容差值，例如 5 像素）
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, _endX, _endY), 5);
        }
    }
}
