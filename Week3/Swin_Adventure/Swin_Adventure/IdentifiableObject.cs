namespace Swin_Adventure
{


    public class IdentifiableObject
    {
        
       protected List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>(idents.Length);
            foreach (var id in idents)
            {
                _identifiers.Add(id.ToLower());
            }
        }
        public List<string> Identifiers
        {
            get { return _identifiers; }
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public void AllId()
        {
            foreach (string id in _identifiers)
            {
                System.Console.WriteLine(id);
            }
        }
        public string FirstId
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        public void RemoveIdentifier(string id)
        {
            _identifiers.Remove(id.ToLower());
        }

        public void PrivilegeEscalation(string pin)
        {
            string studentPin = "5442";
            if (pin == studentPin)
            {
                _identifiers[0] = "cos20007";
            }
        }

    }
}

