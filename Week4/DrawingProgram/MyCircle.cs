using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;
        public int Radius { get => _radius; set => _radius = value; }

        // 默认构造函数：可用 this 语法调用带参数的构造函数，设置默认颜色与默认半径(例如 50 或根据你的学号调整)
        public MyCircle() : this(Color.Blue, 50)
        {
        }

        // 带参数构造函数：这里只传入颜色和半径，位置可使用基类的默认 (0,0)，后面在创建时再设置位置
        public MyCircle(Color color, int radius) : base(color)
        {
            _radius = radius;
        }

        public override void Draw()
        {
            // 绘制圆形：SplashKit 中使用 FillCircle 来填充圆
            SplashKit.FillCircle(Color, X, Y, _radius);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            // 绘制比原圆大 2 像素的黑色轮廓
            SplashKit.DrawCircle(Color.Black, X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            // 检测点击点是否在圆内：可以用 SplashKit 提供的 PointInCircle 方法
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, _radius));
        }
    }
}
