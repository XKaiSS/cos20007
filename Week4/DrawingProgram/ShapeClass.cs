using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;

        // 构造函数：根据首字母设置颜色，参数param为1XX（学号后两位）
        public Shape(int param, string firstName)
        {
            // 判断首字母范围（A-K或L-Z）
            char firstChar = firstName.ToUpper()[0];
            _color = (firstChar >= 'A' && firstChar <= 'K') ? Color.Blue : Color.Yellow;

            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
        }

        // 属性定义（与UML一致）
        public Color Color { get => _color; set => _color = value; }
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public int Width { get => _width; }
        public int Height { get => _height; }

        // 绘制矩形（使用SplashKit的图形API）
        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        // 判断点是否在矩形内（参数改为Point2D）
        public bool IsAt(Point2D pt)
        {
            return pt.X >= _x && pt.X <= _x + _width &&
                   pt.Y >= _y && pt.Y <= _y + _height;
        }
    }
}