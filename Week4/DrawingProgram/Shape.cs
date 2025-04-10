using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;

        private bool _selected;

        public Shape(string name, int param)
        {
            char firstLetter = char.ToUpper(name[0]);
            if (firstLetter >= 'A' && firstLetter <= 'K')
            {
                _color = Color.Azure;
            }
            else
            {
                _color = Color.Chocolate;
            }

            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
        }

        public Color Color { get => _color; set => _color = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public bool Selected { get => _selected; set => _selected = value; }

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public void DrawOutline()
        {
            int lastDigit = 2; // 假设你的学号最后一位是5（按需修改！）
            int padding = 2 + lastDigit; // 外框比形状大 5+X 像素

            // 绘制黑色边框矩形
            SplashKit.DrawRectangle(Color.Black, _x - padding, _y - padding, _width + 2 * padding, _height + 2 * padding);
        }

        public bool IsAt(Point2D pt)
        {
            return (pt.X >= _x && pt.X <= _x + _width) &&
                      (pt.Y >= _y && pt.Y <= _y + _height);
        }
        public bool IsNear(Point2D pt)
        {
            double distance = Math.Sqrt(Math.Pow(pt.X - this.X, 2) + Math.Pow(pt.Y - this.Y, 2));
            return distance <= 50;
        }



    }
}