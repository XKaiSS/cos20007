using System.Runtime.CompilerServices;

using Swin_Adventure;

class Program
{
    static void Main(string[] args)
    {
        List<IHaveInventory> haveInventories= new List<IHaveInventory>();
        Bag bag= new Bag(new string[]{"Bag"}, "Bag", "A big bag");
        Player player= new Player( "Player", "A bad Player");
        haveInventories.Add(bag);
        haveInventories.Add(player);
        foreach (var item in haveInventories)
        {
            System.Console.WriteLine(item.Name);
            var locatedItem= item.Locate("bag");
            if (locatedItem!=null){
                System.Console.WriteLine("Located: {0}",locatedItem.Name);
            }
            else{
                System.Console.WriteLine("Not found");
            }
            
        }



    }

}

