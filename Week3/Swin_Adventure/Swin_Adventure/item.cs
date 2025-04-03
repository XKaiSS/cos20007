namespace Swin_Adventure
{
    public class Item : GameObject
    {

        private string _studentPin = "5442";
        public Item(string[] idents, string name, string description)
        : base(idents, name, description)
        {
        }


        public void PrivilegeEscalation(string pin)
        {
            if (pin == _studentPin && _identifiers.Count > 0)
            {
                _identifiers[0] = "cos20007"; // 直接修改继承的_identifiers
            }
        }
    }



}
