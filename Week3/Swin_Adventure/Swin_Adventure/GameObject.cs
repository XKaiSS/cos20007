
namespace Swin_Adventure{

    public class GameObject : IdentifiableObject
    {

        private readonly string _name;
        private readonly string _description;


        public GameObject(string[] idents,string name, string description)
        : base(idents) 
        {
            _name = name;
            _description = description;
           
            }
        } 





    }
