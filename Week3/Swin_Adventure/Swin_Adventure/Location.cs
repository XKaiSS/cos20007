using System;
using System.Collections.Generic;

namespace Swin_Adventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription
        {
            get
            {
                return $"You are in {Name}\nIn this room you can see:\n{_inventory.ItemList}";
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            // First check inventory
            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }

            // Then check paths
            foreach (Path path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }

            return null;
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }
    }
} 