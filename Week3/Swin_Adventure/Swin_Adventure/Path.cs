using System;

namespace Swin_Adventure
{
    public class Path : GameObject
    {
        private Location _source;
        private Location _destination;

        public Path(string[] ids, string name, string desc, Location source, Location destination) 
            : base(ids, name, desc)
        {
            _source = source;
            _destination = destination;
        }

        public Location Source
        {
            get { return _source; }
        }

        public Location Destination
        {
            get { return _destination; }
        }

        public void Move(Player player)
        {
            if (player.Location == _source)
            {
                player.Location = _destination;
            }
        }
    }
} 