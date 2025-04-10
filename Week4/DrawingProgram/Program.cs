using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        // 定义枚举类型（可以放在 Program 类外部也是可以的）
        public enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            

            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();

            // 当前要添加的形状类型，默认是 Rectangle（也可以默认是 Circle，根据需求）
            
            ShapeKind kindToAdd = ShapeKind.Rectangle;
            string x = "0";
            
           

            do
            {
                SplashKit.ProcessEvents();

                // 根据键盘输入切换形状类型
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Point2D mousePos = SplashKit.MousePosition();
                    Shape newShape = null;
                    switch (kindToAdd)
                    {
                        case ShapeKind.Rectangle:
                            // 这里使用学号相关参数调整默认宽高，例如 100 + 最后两位数字（此处简单设为100,100）
                            newShape = new MyRectangle(Color.Green, (float)mousePos.X, (float)mousePos.Y, 100, 100);
                            break;
                        case ShapeKind.Circle:
                            newShape = new MyCircle(Color.Blue, 50); // 默认半径50，你可以根据需求调整
                            // 设置圆心位置：利用基类属性
                            newShape.X = (float)mousePos.X;
                            newShape.Y = (float)mousePos.Y;
                            break;
                        case ShapeKind.Line:
                            // 创建直线时，起始位置为鼠标位置，终点使用一个固定偏移（例如 50 像素偏移）
                            newShape = new MyLine(Color.Red, (float)mousePos.X, (float)mousePos.Y, (float)mousePos.X + 50, (float)mousePos.Y + 50);
                            break;
                    }
                    if (newShape != null)
                    {
                        myDrawing.AddShape(newShape);
                    }
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    List<Shape> selected = myDrawing.SelectedShapes;
                    myDrawing.DeleteShapes(selected);
                }

                myDrawing.Draw();
                SplashKit.RefreshScreen(60);

            } while (!window.CloseRequested);
        }
    }
}
