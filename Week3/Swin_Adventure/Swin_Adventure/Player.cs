namespace Swin_Adventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Inventory Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public Location Location
        {
            get { return _location; }
            set { _location = value; }
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
            GameObject obj = Inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }
            if (_location != null)
            {
                return _location.Locate(id);
            }
            return null;
        }

        public override string FullDescription
        {
            get { return $"You are {Name}, {base.FullDescription}\nYou are carrying:\n" + _inventory.ItemList; }
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