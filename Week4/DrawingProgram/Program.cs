using System;
using SplashKitSDK;



namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            
            // 初始化Shape对象：假设学号末两位为"99"，首字母为"Z"
            Shape myShape = new Shape(142, "XiKai");  // 参数为1XX（199）

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                // 绘制形状

                // 处理鼠标左键点击事件
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

                // 处理空格键事件
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    Point2D mousePos = SplashKit.MousePosition();
                    if (myShape.IsAt(mousePos))
                    {
                        myShape.Color = SplashKit.RandomColor();
                    }
                }
                 myShape.Draw();

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}