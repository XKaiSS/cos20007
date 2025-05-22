using System.Runtime.CompilerServices;

using Swin_Adventure;
using Path = Swin_Adventure.Path;

class Program
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("please enter your name");
        string playerName = Console.ReadLine();
        System.Console.WriteLine("please enter your description");
        string playerdescription = Console.ReadLine();
        Player player = new Player(playerName, playerdescription);

        // Create locations
        Location room = new Location(new string[] { "room" }, "a small room", "A small room with a single window.");
        Location room2 = new Location(new string[] { "room2" }, "a small room2", "A small room2 with a single window.");
        
        // Create paths between rooms
        Path northPath = new Path(new string[] { "north" }, "north path", "A path leading north to room2", room, room2);
        Path southPath = new Path(new string[] { "south" }, "south path", "A path leading south to room1", room2, room);
        
        // Add paths to rooms
        room.AddPath(northPath);
        room2.AddPath(southPath);
        
        // Set player's initial location
        player.Location = room;

        // Create items
        Item sword = new Item(new string[] { "sword" }, "a rusty sword", "A sharp rusty sword");
        Item potion = new Item(new string[] { "potion" }, "a healing potion", "A small red healing potion");
        player.Inventory.Put(sword);
        player.Inventory.Put(potion);

        // Create a bag
        Bag bag = new Bag(new string[] { "bag", "bigbag" }, "a leather bag", "A worn-out leather bag");
        player.Inventory.Put(bag);
        Item gem = new Item(new string[] { "gem" }, "a shiny gem", "A sparkling shiny gem");
        bag.Inventory.Put(gem);

        // Add some items to the rooms
        Item chair = new Item(new string[] { "chair" }, "a wooden chair", "A sturdy wooden chair");
        Item table = new Item(new string[] { "table" }, "a wooden table", "A small wooden table");
        room.Inventory.Put(chair);
        room.Inventory.Put(table);

        // Create commands
        LookCommand lookCommand = new LookCommand();
        MoveCommand moveCommand = new MoveCommand();
        bool finished = false;

        Console.WriteLine("\nWelcome to the game!");
        Console.WriteLine("Available commands:");
        Console.WriteLine("- look [item/location]");
        Console.WriteLine("- move/go [direction]");
        Console.WriteLine("- exit");

        while (!finished)
        {
            Console.WriteLine("\nEnter a command:");
            string command = Console.ReadLine();

            if (command.ToLower() == "exit")
            {
                finished = true;
                break;
            }

            string[] split = command.Split(" ");
            string result;

            if (lookCommand.AreYou(split[0].ToLower()))
            {
                result = lookCommand.Execute(player, split);
            }
            else if (moveCommand.AreYou(split[0].ToLower()))
            {
                result = moveCommand.Execute(player, split);
            }
            else
            {
                result = "I don't understand that command.";
            }

            Console.WriteLine(result);
        }
    }
}

