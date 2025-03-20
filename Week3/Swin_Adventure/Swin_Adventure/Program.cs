using System.Runtime.CompilerServices;

using Swin_Adventure;

class Program
{
    static void Main(string[] args)
    {

        string[] weaponId = new string[3];
        weaponId[0]="剑";
        weaponId[1]= "刀";
        weaponId[2]= "枪";
        Item weapon = new Item(weaponId, "多功器能武", "点击武器上的按钮可以变换武器形态");
        System.Console.WriteLine(weapon.FirstId());
        System.Console.WriteLine(weapon.LongDescription);
        System.Console.WriteLine(weapon.ShortDescription);
        System.Console.WriteLine(weapon.AreYou("鞭子"));


    }
}
