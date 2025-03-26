class ShapeDrawing{


    private string _color;
    private float _x;
    private float _y;
    private int _width;
    private int _height;

   public ShapeDrawing(){
        _color = "Chocolate";
        _x = 2.0f;
        _y = 2.0f;
        _width = 10;
        _height = 10;
    }

    
    public string Color {
        get{
            return _color;
        }

        set {
            _color = value;
        }
    }
    public float X{
        get{
            return _x;
        }


    }
    public float Y {

        get{
            return _y;
        }

    }

    public float Width{

        get{
            return _width;
        }
    }
     public float Height{

        get{
            return _height;
        }
    }

    public void IsAt (int x, int y){

        if ((x*y) <= (Width * Height)){
            System.Console.WriteLine("This point is in this shape");
        }
        else{
            System.Console.WriteLine("This point is not in this shape");
        }

    }

    public void Draw (){

        System.Console.WriteLine("Color is {0}", Color);
        System.Console.WriteLine("Position X is {0}", X);
        System.Console.WriteLine("Position Y is {0}", Y);
        System.Console.WriteLine("Width is {0}", Width);
        System.Console.WriteLine("Height is {0}", Height);
    }
}

