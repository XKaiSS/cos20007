
namespace Swin_Adventure
{

    public abstract class GameObject : IdentifiableObject
    {

        private readonly string _name;
        private readonly string _description;


        public GameObject(string[] idents, string name, string description)
        : base(idents)
        {
            _name = name;
            _description = description;

        }

        
        public string Name
        {
            get { return _name; }
        }
        public virtual string FullDescription 
        {
            get { return _description; }
        } // Virtual allows subclasses to override
        public string ShortDescription
        {
            get { return $"a {_name} ({FirstId})"; }
        }

    }
}







