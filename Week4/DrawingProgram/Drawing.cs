using System;
using SplashKitSDK;
using System.IO;
using System.Collections.Generic;

using MyGame;



namespace ShapeDrawer
{


    public class Drawing
    {

        // Field
        public readonly List<Shape> _shapes;
        private Color _background;


        // Constructor
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

        //lab task
        public void DeleteShapes(List<Shape> toDelete)
        {
            // Calculate the remaining quantity after deletion
            int remaining = _shapes.Count - toDelete.Count;
            if (remaining >= 3)
            {
                // then can delete
                foreach (var shape in toDelete)
                    _shapes.Remove(shape);
            }
        }



        public void Draw()
        {
            SplashKit.ClearScreen(_background); // 清屏并填充背景色
            foreach (Shape s in _shapes)
                s.Draw(); // 让每个形状自己绘制
        }


        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
                s.Selected = s.IsAt(pt); // 调用形状的IsAt方法判断是否选中
        }





        public void Save(string filename)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filename);
                // 1. 写背景色
                writer.WriteColor(this.Background);
                // 2. 写形状数
                writer.WriteLine(this.ShapeCount);
                // 3. 逐个委托 Shape 将自己写入
                foreach (var s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                // 无论成功或异常都要关闭文件
                if (writer != null) writer.Close();
            }
        }

        public void Load(string filename)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filename);
                // 1. 读背景色
                this.Background = reader.ReadColor();
                // 2. 读形状数
                int count = reader.ReadInteger();
                // 3. 清空已有
                _shapes.Clear();
                // 4. 逐个根据类型标识读入
                for (int i = 0; i < count; i++)
                {
                    string kind = reader.ReadLine();
                    Shape s = null;
                    switch (kind)
                    {
                        case "Rectangle": s = new MyRectangle(); break;
                        case "Circle":    s = new MyCircle();    break;
                        case "Line":      s = new MyLine();      break;
                        case "Triangle":  s = new MyTriangle(); break;
                        default:
                            throw new InvalidDataException("Error at shape: " + kind);
                    }
                    s.LoadFrom(reader);
                    _shapes.Add(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }

        




    }

}



