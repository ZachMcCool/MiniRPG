using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRPG.Repository
{
    public class CharacterRepository
    {
        List<Character> _characterList = new List<Character>();

        // CRUD

        // Create
        public void AddCharacterToList(Character character)
        {
            _characterList.Add(character);
        }

        // Read
        public List<Character> GetAllCharacters()
        {
            return _characterList;
        }

        // Seed Data Method
        public void SeedData()
        {
            Character ulrich = new Character("Ulrich", ClassType.Fighter, Ancestry.Human, 12);
            Character brox = new Character("Brox", ClassType.Thief, Ancestry.HalfOrc, 5);
            Character akira = new Character("Akira Gozen", ClassType.Fighter, Ancestry.Elf, 16);
            Character badger = new Character("Badger Wartooth", ClassType.MagicUser, Ancestry.Tiefling, 11);
            Character draco = new Character("Draco Alavant", ClassType.Fighter, Ancestry.HalfOrc, 7);
            Character phyrra = new Character("Phyrra T'soryn", ClassType.Cleric, Ancestry.HalfElf, 3);
            Character angert = new Character("Angert", ClassType.MagicUser, Ancestry.Halfing, 9);

            Character[] characterArray = { ulrich, brox, akira, badger, draco, phyrra, angert };

            foreach (Character character in characterArray)
            {
                AddCharacterToList(character);
            }
        }
        public Character GetCharacterFromListByName(string userInputCharacterSeach)
        {
            foreach (Character character in _characterList)
            {
                if (character.CharacterName.ToUpper() == userInputCharacterSeach.ToUpper())
                {
                    return character;
                }
            }
            return null;
        }
    }
}