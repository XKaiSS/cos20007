namespace Swin_Adventure
{

    public abstract class GameObject : IdentifiableObject
    {

        private string _name;
        private  string _description;

        public GameObject(string[] idents, string name, string description)
        : base(idents)
        {
            _name = name;
            _description = description;

        }
 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public virtual string FullDescription{
            get{ return _description; }
        }
       // Virtual allows subclasses to override
        public string ShortDescription
        {
            get { return $"{_name} ({FirstId})"; }
        }

        public virtual void SaveTo(StreamWriter Writer){

            Writer.WriteLine(_name);
            Writer.WriteLine(_description);
        }
        public virtual void LoadFrom(StreamReader Reader){
            _name = Reader.ReadLine();
            _description = Reader.ReadLine();
        }

    }
}







