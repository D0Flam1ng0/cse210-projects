using System;

class Program
{
    static void Main(string[] args)
    {
        CharacterManager manager = new CharacterManager();
        manager.LoadCharacters();

        while (true)
        {
            Console.WriteLine("\nD&D Character Creator");
            Console.WriteLine("1. Create New Character");
            Console.WriteLine("2. View Existing Characters");
            Console.WriteLine("3. Exit");
            Console.Write("Select option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CharacterBuilder builder = new CharacterBuilder();
                Character character = builder.BuildCharacter();
                manager.SaveCharacter(character);
                character.DisplaySheet();
            }
            else if (choice == "2")
            {
                manager.DisplayCharacterList();
                Console.Write("Enter number to view: ");
                if (int.TryParse(Console.ReadLine(), out int index))
                    manager.ViewCharacterDetails(index - 1);
            }
            else if (choice == "3")
                break;
        }
    }
}

