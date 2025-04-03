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
            Drawing myDrawing = new Drawing();

            do
            {
                SplashKit.ProcessEvents();
                //SplashKit.ClearScreen(Color.White); //clear screen

                // If the left mouse button is clicked, and mouse position is in the shape,update the shape position
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Point2D mousePos = SplashKit.MousePosition();
                    Shape newShape = new Shape("XiKai", 123) // 创建新形状
                    {
                        X = (float)mousePos.X,
                        Y = (float)mousePos.Y
                    };
                    myDrawing.AddShape(newShape);
                }
                
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }
                
                

                // If the spacebar is pressed and the mouse is inside the shape, change color
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    Point2D mousePos = SplashKit.MousePosition();
                    Shape hoveredShape = myDrawing.FindHoveredShape(mousePos);
                    
                    hoveredShape.Color = SplashKit.RandomRGBColor(255);
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }


                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    List<Shape> selected = myDrawing.SelectedShapes;
                    foreach (Shape s in selected)
                        myDrawing.RemoveShape(s);
                }

                myDrawing.Draw();
                SplashKit.RefreshScreen(60);

            } while (!window.CloseRequested);
        }
    }
}

