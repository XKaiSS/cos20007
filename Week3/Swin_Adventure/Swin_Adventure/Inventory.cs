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
                List<string> descriptionList = new List<string>();
                foreach (var item in _items)
                {
                    descriptionList.Add(item.ShortDescription);
                }
                list = string.Join(", ", descriptionList);
                return list;
            }
        }

        public bool PutItemWithLimit(Item itm)
        {
            // 条件1： Check if the number of identifiers is less than 3
            if (itm.Identifiers.Count >= 3)
            {
                return false;
            }

            // 条件2： Check if an item with the same identifier already exists
            foreach (var existingItem in _items)
            {
                foreach (var id in itm.Identifiers)
                {
                    if (existingItem.AreYou(id))
                    {
                        return false;
                    }
                }
            }

            // If the conditions are met, then add item
            _items.Add(itm);
            return true;
        }
    }
}