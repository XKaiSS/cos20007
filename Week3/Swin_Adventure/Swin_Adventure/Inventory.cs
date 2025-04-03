namespace Swin_Adventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach (var item in _items)
            {
                if (item.AreYou(id)) return true;
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (var item in _items)
            {
                if (item.AreYou(id))
                {
                    _items.Remove(item);
                    return item;
                }
            }
            return null;
        }

        public Item Fetch(string id)
        {
            foreach (var item in _items)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }
        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }

        public string ItemList
        {
            get
            {
                string list = "";
                foreach (var item in _items)
                {
                    list += "\t" + item.ShortDescription + "\n";
                }
                return list.TrimEnd();
            }
        }
    }
}