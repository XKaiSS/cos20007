
namespace Swin_Adventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        public Inventory Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }
        public Player(string name, string description)
        : base(new string[] { "me", "inventory" }, name, description)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            else
            {
                return Inventory.Fetch(id);
            }
        }
        public override string FullDescription
        {
            get { return $"You are {Name}, {base.FullDescription}\nYou are carring:\n" + _inventory.ItemList; }
        }

        public override void SaveTo(StreamWriter Writer)
        {
            base.SaveTo(Writer);
            Writer.WriteLine(_inventory.ItemList);
        }
        public override void LoadFrom(StreamReader Reader)
        {
            base.LoadFrom(Reader);
            string ItemList = Reader.ReadLine();
            System.Console.WriteLine("Player information");
            System.Console.WriteLine(Name);
            System.Console.WriteLine(ShortDescription);
            System.Console.WriteLine(ItemList);
            System.Console.WriteLine(FullDescription);
        }
    }
}