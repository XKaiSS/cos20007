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
        Item sword = new Item(new string[] { "sword" }, "Sword", "A sharp blade");
        Inventory bag = new Inventory();
        bag.Put(weapon);
        bag.Put(sword);
        System.Console.WriteLine(bag.ItemList);


    }

    
}

class Teacher{

    string Name;
    int age;

 public Teacher(string name, int age){
    Name = name;
     Age = age;
}

   
}
