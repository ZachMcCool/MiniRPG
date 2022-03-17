using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniRPG.Repository;

namespace MiniRPG.ConsoleApp
{
    public class UserInterface
    {
        bool isRunning = true;

        CharacterRepository _repo = new CharacterRepository();
        // CustomConsole _console = new CustomConsole();

        // Run() method
        public void Run()
        {
            _repo.SeedData();

            while (isRunning)
            {
                // _console.PrintMainMenu();
                Console.WriteLine("\n1. Create A Character" +
                "\n2. View All Characters" +
                "\n3. View One Character" +
                "\n4. Exit Application"
                );
                // _console.EnterSelection();
                Console.Write("\nEnter Selection");
                string input = GetUserInput();

                UserInputSwitchCase(input);
            }
        }

        private string GetUserInput()
        {
            return Console.ReadLine();
        }
        private void UserInputSwitchCase(string input)
        {
            switch (input)
            {
                case "1":
                    CreateACharacter();
                    break;
                case "2":
                    ViewAllCharacters();
                    break;
                case "3":
                    ViewOneCharacter();
                    break;
                case "4":
                    ExitApplication();
                    break;
                default:

                    break;
            }
        }
        // CreateACharacter() method
        private void CreateACharacter()
        {
            Console.WriteLine("\nWhat is your character's Name?");
            string characterName = GetUserInput();

            Console.WriteLine("\nChoose a class:" +
            "\n1. Fighter" +
            "\n2. Magic-User" +
            "\n3. Cleric" +
            "\n4. Thief"
            );
            string classInput = GetUserInput();
            ClassType classType = ClassType.Fighter;

            switch (classInput)
            {
                case "1":
                    classType = ClassType.Fighter;
                    break;
                case "2":
                    classType = ClassType.MagicUser;
                    break;
                case "3":
                    classType = ClassType.Cleric;
                    break;
                case "4":
                    classType = ClassType.Thief;
                    break;
                default:
                    break;
            }

            Console.WriteLine("\nChoose an ancestry:" +
            "\n1. Human" +
            "\n2. Dwarf" +
            "\n3. Elf" +
            "\n4. Halfling" +
            "\n5. Gnome" +
            "\n6. Half-Orc" +
            "\n7. Half-Elf" +
            "\n8. Tiefling"
            );
            string ancestryInput = GetUserInput();
            Ancestry typeOfAncestry = Ancestry.Human;

            switch (ancestryInput)
            {
                case "1":
                    typeOfAncestry = Ancestry.Human;
                    break;
                case "2":
                    typeOfAncestry = Ancestry.Dwarf;
                    break;
                case "3":
                    typeOfAncestry = Ancestry.Elf;
                    break;
                case "4":
                    typeOfAncestry = Ancestry.Halfing;
                    break;
                case "5":
                    typeOfAncestry = Ancestry.Gnome;
                    break;
                case "6":
                    typeOfAncestry = Ancestry.HalfOrc;
                    break;
                case "7":
                    typeOfAncestry = Ancestry.HalfElf;
                    break;
                case "8":
                    typeOfAncestry = Ancestry.Tiefling;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Enter your character's level (1-20)" +
            "\nThis application does not support multiclass levels");
            int level = Convert.ToInt32(GetUserInput());

            Character newCharacter = new Character(characterName, classType, typeOfAncestry, level);

            _repo.AddCharacterToList(newCharacter);


        }


        // View all Characters
        private void ViewAllCharacters()
        {
            List<Character> characterList = _repo.GetAllCharacters();

            foreach (Character character in characterList)
            {
                Console.WriteLine($"NAME: {character.CharacterName} | CLASS: {character.TypeOfClass} | ANCESTRY: {character.TypeOfAncestry} | LEVEL: {character.Level} | IS MAGIC: {character.IsMagic}");
            }
            Console.WriteLine("Press any key to continue...");
        }

        // ViewOneCharacter
        private void ViewOneCharacter()
        {
            Console.WriteLine("Enter a Character's Name: ");
            string cName = GetUserInput();

            Character character = _repo.GetCharacterFromListByName(cName);

            if (character != null)
            {
                Console.WriteLine($"NAME: {character.CharacterName} | CLASS: {character.TypeOfClass} | ANCESTRY: {character.TypeOfAncestry} | LEVEL: {character.Level} | IS MAGIC: {character.IsMagic}");

                Console.WriteLine("Press any key to continue...");
            }
            else
            {
                Console.WriteLine("We couldn't find that character.  Press any key to continue...");
            }
        }


        // Exit
        private void ExitApplication()
        {
            isRunning = false;
            Console.WriteLine("\nExit Application");
        }
    }
}
