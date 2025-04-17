using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        // define enum
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

            // The shape type to be added currently, the default is Rectangle.

            ShapeKind kindToAdd = ShapeKind.Rectangle;




            do
            {
                SplashKit.ProcessEvents();

                // Switch shape type based on keyboard input
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
                            // use the student ID related parameters to adjust the default width and heigh
                            newShape = new MyRectangle(Color.Green, (float)mousePos.X, (float)mousePos.Y, 100, 42);
                            break;
                        case ShapeKind.Circle:
                            newShape = new MyCircle(Color.Blue, 50); // 半径50
                            // Set the center position: Using base class properties
                            newShape.X = (float)mousePos.X;
                            newShape.Y = (float)mousePos.Y;
                            break;
                        case ShapeKind.Line:

                            int x = 2; // X is the last digit of your student ID
                            if (x == 0) x = 5;

                            for (int i = 0; i < x; i++)
                            {
                                float offset = i * 5; // adjust spacing between lines
                                newShape = new MyLine(Color.Red,
                                                      (float)mousePos.X,
                                                      (float)mousePos.Y + offset,
                                                      (float)mousePos.X + 50,
                                                      (float)mousePos.Y + 50 + offset);
                                myDrawing.AddShape(newShape);
                            }
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
