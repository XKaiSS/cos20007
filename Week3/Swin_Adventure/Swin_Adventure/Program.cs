using System.Runtime.CompilerServices;

namespace Swin_Adventure;

class Program
{
    static void Main(string[] args)
    {

        string[] arrayCat = new string[3];
        arrayCat[0]="";
        arrayCat[1]= "德文";
        arrayCat[2]= "中华田园";
        IdentifiableObject cat = new IdentifiableObject(arrayCat);
        System.Console.WriteLine(cat.FirstId);
        cat.AllId();
        cat.PrivilegeEscalation("5442");

        System.Console.WriteLine(cat.FirstId);


    }
}
