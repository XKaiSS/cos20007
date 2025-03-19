using System.Security.Cryptography.X509Certificates;
namespace CounterTask;
class Program
{
    public static void PrintCounters(Counter[]counters){
     foreach(Counter counter in counters){
        System.Console.WriteLine("{0} is {1}" , counter.Name, counter.Ticks);
     }
    }


    static void Main(string[] args)
    {
        Counter[] myCounter = new Counter[3];
        myCounter[0] = new Counter("Counter1");
        myCounter[1] = new Counter("Counter2");
        myCounter[2] = myCounter[0];
        
        for(long i = myCounter[0].Ticks ; i < 9; i++){
            myCounter[0].Increment();
        }
        for(long i = myCounter[1].Ticks ; i < 14; i++){
            myCounter[1].Increment();
        }

        myCounter[0].ResetByDefault();
        myCounter[1].Reset();
        
        for(long i = myCounter[1].Ticks ; i < 14; i++){
            myCounter[1].IncrementBy5();
        }
        PrintCounters(myCounter); //still run without any bugs/crash
    }
}
