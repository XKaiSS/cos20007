using System.Runtime.CompilerServices;

using Swin_Adventure;

class Program
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("please enter your name");
        string playerName = Console.ReadLine();
         System.Console.WriteLine("please enter your descroption");
        string playerdescription = Console.ReadLine();
        Player player = new Player(playerName, playerdescription);
        Item sword = new Item(new string[] { "sword" }, "a rusty sword", "A sharp rusty sword");
        Item potion = new Item(new string[] { "potion" }, "a healing potion", "A small red healing potion");
        player.Inventory.Put(sword);
        player.Inventory.Put(potion);
        Bag bag = new Bag(new string[] { "bag","bigbag" }, "a leather bag", "A worn-out leather bag");
        player.Inventory.Put(bag);
        Item gem = new Item(new string[] { "gem" }, "a shiny gem", "A sparkling shiny gem");
        bag.Inventory.Put(gem);
        LookCommand lookCommand = new LookCommand(new string[] { "" });
        bool finished = false;

        while (!finished)
        {
            Console.WriteLine("Enter a command");
            string command = Console.ReadLine();

            if (command.ToLower() == "exit")
            {
                finished = true;
                break;
            }

            string[] split = command.Split(" ");

            Console.WriteLine(lookCommand.Execute(player, split));
        }

    }
}

