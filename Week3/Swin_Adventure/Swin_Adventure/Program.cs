using System.Runtime.CompilerServices;

using Swin_Adventure;

class Program
{
    static void Main(string[] args)
    {

        string[] weaponId = new string[3];
        weaponId[0] = "sword";
        weaponId[1] = "knife";
        weaponId[2] = "spear";
        Item weapon = new Item(weaponId, "Multi-functional Weapon", "Pressing the button on the weapon changes its form.");
        Item sword = new Item(new string[] { "sword" }, "Sword", "A sharp blade");
        Inventory bag = new Inventory();
        bag.Put(weapon);
        bag.Put(sword);
        bag.RemoveItem(weapon);
        System.Console.WriteLine(bag.ItemList);




    }
}
