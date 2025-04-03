using System;
using SplashKitSDK;


namespace ShapeDrawer
{


    public class Drawing
    {

        // 字段
        public readonly List<Shape> _shapes;
        private Color _background;


        //构造函数 Constructor
        public Drawing()
        {
            _shapes = new List<Shape>();
            _background = Color.White;
        }
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        //Property
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape s in _shapes)
                    if (s.Selected) result.Add(s);
                return result;
            }
        }

        public int ShapeCount
        {
            get
            {
                return _shapes.Count;
            }
        }

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }


        // method

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background); // 清屏并填充背景色
            foreach (Shape s in _shapes)
                s.Draw(); // 让每个形状自己绘制
        }

        public Shape FindHoveredShape(Point2D mousePos)
        {
            foreach (Shape shape in _shapes) // 内部遍历 _shapes
            {
                if (shape.IsAt(mousePos))
                    return shape;
            }
            return null;

             // 没有悬停的图形
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
                s.Selected = s.IsAt(pt); // 调用形状的IsAt方法判断是否选中
        }

    }

}



