using System;
using SplashKitSDK;


namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {

            string name = "XiKai"; // first name
            int param = 142; // 1XX, XX is my last two digitals of student id

            Window window = new Window("Shape Drawer", 800, 600);
            Shape myShape = new Shape(name, param);

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.White); //clear screen

                // If the left mouse button is clicked, and mouse position is in the shape,update the shape position
                if (SplashKit.MouseClicked(MouseButton.LeftButton)&& myShape.IsAt(SplashKit.MousePosition()))
                {
                    myShape.X = SplashKit.MouseX() - myShape.Width / 2;
                    myShape.Y = SplashKit.MouseY() - myShape.Height / 2;
                }

                // If the spacebar is pressed and the mouse is inside the shape, change color
                if (SplashKit.KeyTyped(KeyCode.SpaceKey) && myShape.IsNear(SplashKit.MousePosition()))
                {
                    myShape.Color = SplashKit.RandomRGBColor(255);
                }

                myShape.Draw();
                SplashKit.RefreshScreen(60);

            } while (!window.CloseRequested);
        }
    }
}

