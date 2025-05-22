using System;

namespace Swin_Adventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go" })
        {
        }

        public override string Execute(Player player, string[] text)
        {
            if (text.Length < 2)
            {
                return "Move where?";
            }

            if (!AreYou(text[0]))
            {
                return "Error in move input";
            }

            string direction = text[1];
            GameObject path = player.Location.Locate(direction);

            if (path == null)
            {
                return $"I cannot find the {direction} path";
            }

            if (path is Path)
            {
                Path movePath = (Path)path;
                movePath.Move(player);
                return $"You have moved {direction} to {player.Location.Name}";
            }

            return $"I cannot find the {direction} path";
        }
    }
} 