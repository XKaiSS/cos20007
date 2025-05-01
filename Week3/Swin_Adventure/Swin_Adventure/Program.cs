using System.Runtime.CompilerServices;

using Swin_Adventure;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("Xikai", "A killer!");
        Item sword = new Item(new string[] { "sword", "weapon" }, "A sword", "A sharp sword");
        Item shield = new Item(new string[] { "shield", "defence" }, "A shield", "A strong shield");
        player.Inventory.Put(sword);
        player.Inventory.Put(shield);

        StreamWriter streamWriter = new StreamWriter("TestPlayer.txt");
        try
        {
            player.SaveTo(streamWriter);

        }
        catch (System.Exception)
        {

            throw;
        }
        finally
        {
            streamWriter.Close();
        }

        StreamReader streamReader = new StreamReader("TestPlayer.txt");
        try
        {
            player.LoadFrom(streamReader);

        }
        catch (System.Exception)
        {

            throw;
        }
        finally
        {
            streamReader.Close();
        }
    }
}

