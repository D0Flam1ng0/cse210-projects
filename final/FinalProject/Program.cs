using System;

class Program
{
    static void Main(string[] args)
    {
        CharacterManager manager = new CharacterManager();
        manager.LoadCharacters();

        while (true)
        {
            Console.WriteLine("\n=== D&D Character Creator ===");
            Console.WriteLine("1. Create New Character");
            Console.WriteLine("2. View Existing Characters");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CharacterBuilder builder = new CharacterBuilder();
                    Character newCharacter = builder.BuildCharacter();
                    manager.SaveCharacter(newCharacter);
                    Console.WriteLine("\nCharacter successfully created!");
                    newCharacter.DisplaySheet();
                    break;

                case "2":
                    if (manager.Characters.Count == 0)
                    {
                        Console.WriteLine("No characters found.");
                        break;
                    }

                    manager.DisplayCharacterList();
                    Console.Write("Enter the number of the character to view: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        manager.ViewCharacterDetails(index - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid selection. Try again.");
                    break;
            }
        }
    }
}
