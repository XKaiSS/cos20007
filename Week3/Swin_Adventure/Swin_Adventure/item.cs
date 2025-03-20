namespace Swin_Adventure{
    public class Item
    {
        private IdentifiableObject _identifiable; 
        private string _name;
        private string _description;
        public Item(string[] idents, string name, string description)
        {
            _identifiable = new IdentifiableObject(idents);
            _name = name;
            _description = description;
        }

        public string Name
        {
            get { return _name; }
        }

        public string ShortDescription
        {
            get { return $"a {_name} ({_identifiable.FirstId})"; }
        }

        public string LongDescription
        {
            get { return _description; }
        }
        public bool AreYou(string id)
        {
            return  _identifiable.AreYou(id);
        }

        public void AddIdentifier(string id)
        {
            _identifiable.AddIdentifier(id);
        }

        public string FirstId(){
            return _identifiable.FirstId;
        }
    }

}