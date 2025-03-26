namespace CounterTask;

 
public class Counter{

    private long _count;

    public  long Ticks{
        get{
            return _count;
        }
    }
    private string _name;

    public string Name{
        get{
           return _name;
        }

        set{
            _name = value;
        }
    }
    private long _defaultCount;

    public Counter(string name){

        _name = name;
        _count = 0;
        _defaultCount = 214748365442;
    }

    public long Increment(){

        _count = _count + 1;
        return _count;

    }
     public long IncrementBy5(){

        _count = _count + 5;
        return _count;

    }
    public long Reset(){

        _count = 0;

        return _count;

    }

    public long ResetByDefault(){
        _count = _defaultCount;

        return _count;
    }



}
