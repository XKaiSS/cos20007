using System;
using SplashKitSDK;

namespace ShapeDrawer{
public class Shape
{
    private Color _color;
    private float _x, _y;
    private int _width, _height;

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

    public void Draw()
    {
        SplashKit.FillRectangle(_color, _x, _y, _width, _height);
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