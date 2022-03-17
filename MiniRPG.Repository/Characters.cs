using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRPG.Repository
{
    public enum ClassType { Fighter, MagicUser, Cleric, Thief }
    public enum Ancestry { Human, Dwarf, Elf, Halfing, Gnome, HalfOrc, HalfElf, Tiefling }

    // Character is our Base Class
    public class Character
    {
        public string CharacterName { get; set; }
        public ClassType TypeOfClass { get; set; }

        public Ancestry TypeOfAncestry { get; set; }
        public int Level { get; set; }

        public Character(string characterName, ClassType typeOfClass, Ancestry typeOfAncestry, int level)
        {
            CharacterName = characterName;
            TypeOfClass = typeOfClass;
            TypeOfAncestry = typeOfAncestry;
            Level = level;
        }

        public bool IsMagic
        {
            get
            {
                if (TypeOfClass == ClassType.MagicUser || TypeOfClass == ClassType.Cleric)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
