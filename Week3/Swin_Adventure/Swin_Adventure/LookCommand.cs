using System;
namespace Swin_Adventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }
        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 1 && text[0] == "look")
            {
                if (p.Location != null)
                {
                    return p.Location.FullDescription;
                }
                return "You are not in any location.";
            }

            IHaveInventory container = p;

            if (text.Length == 3 || text.Length == 5)
            {
                if (text[0] == "look")
                {
                    if (text[1] == "at")
                    {
                        if (text.Length == 5)
                        {
                            if (text[3] == "in")
                            {
                                container = FetchContainer(p, text[4]);
                                if (container == null)
                                {
                                    return "I cannot find the " + text[4];
                                }
                            }
                            else return "What do you want to look in?";
                        }
                        return LookAtIn(text[2], container);
                    }
                    else return "What do you want to look at?";
                }
                else return "Error in look input";
            }
            return "I do not know how to look like that";
        }
        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            GameObject obj = p.Locate(containerId);
            if (obj == null)
            {
                return null;
            }
            else
            {
                IHaveInventory container = obj as IHaveInventory;
                return container;
            }
        }
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject itm = container.Locate(thingId);
            if (itm == null)
            {
                return "I can't find the " + thingId;
            }
            return itm.FullDescription;
        }
    }
}