using System;
using SplashKitSDK;


namespace ShapeDrawer
{
   public class Program
{
    public static void Main()
    {

        string name = "XiKai"; // first name
        int param = 123; // 1XX, XX is my last two digitals of student id
        
        Window window = new Window("Shape Drawer", 800, 600);
        Shape shape = new Shape(name, param);

        while (!window.CloseRequested)
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen(Color.Black);
            shape.Draw();

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Point2D mousePos = SplashKit.MousePosition();
                if (shape.IsAt(mousePos))
                {
                    shape.X = (float)mousePos.X - shape.Width / 2;
                    shape.Y = (float)mousePos.Y - shape.Height / 2;
                }
            }

            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                shape.Color = SplashKit.RandomRGBColor(255);
            }

            SplashKit.RefreshScreen(60);
        }
    }
}

}