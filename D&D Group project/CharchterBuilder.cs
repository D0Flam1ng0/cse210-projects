using System;
using System.Collections.Generic;

public class CharacterBuilder
{
    private List<CharacterClass> AvailableClasses = new();
    private List<Subclass> AvailableSubclasses = new();

    public CharacterBuilder()
    {
        // Initialize available classes and subclasses here
        var rogue = new CharacterClass("Rogue", 8, "Dexterity");
        rogue.AddAbility(1, new Ability("Sneak Attack", "Bonus damage"));
        rogue.AddAbility(2, new Ability("Cunning Action", "Bonus action to dash, disengage, or hide"));
        AvailableClasses.Add(rogue);

        var assassin = new Subclass("Assassin", "Rogue");
        assassin.AddAbility(3, new Ability("Assassinate", "Advantage on surprised enemies"));
        AvailableSubclasses.Add(assassin);
    }

    public Character BuildCharacter()
    {
        Character character = new Character();

        Console.Write("Enter character name: ");
        character.Name = Console.ReadLine();

        character.Race = ChooseRace();

        Console.Write("Enter level (1-20): ");
        character.Level = int.Parse(Console.ReadLine());

        character.AbilityScores = InputStats();

        ChooseClassesAndSubclasses(character);

        return character;
    }

    public Race ChooseRace()
    {
        var elf = new Race("Elf",
            new Dictionary<string, int> { { "Dexterity", 2 }, { "Intelligence", 1 } },
            new List<Ability> { new("Darkvision", "See in dark"), new("Fey Ancestry", "Advantage vs charm") });

        Console.WriteLine("Choose Race: 1. Elf (default)");
        return elf;
    }

    public void ChooseClassesAndSubclasses(Character character)
    {
        Console.WriteLine("Choose number of classes (e.g., 1 or 2 for multiclassing):");
        int classCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < classCount; i++)
        {
            Console.WriteLine("Available Classes:");
            for (int j = 0; j < AvailableClasses.Count; j++)
                Console.WriteLine($"{j + 1}. {AvailableClasses[j].Name}");

            Console.Write($"Choose class #{i + 1}: ");
            int classChoice = int.Parse(Console.ReadLine()) - 1;
            var selectedClass = AvailableClasses[classChoice];
            character.Classes.Add(selectedClass);

            Console.WriteLine("Available Subclasses:");
            List<Subclass> filtered = AvailableSubclasses.FindAll(s => s.ParentClass == selectedClass.Name);
            for (int j = 0; j < filtered.Count; j++)
                Console.WriteLine($"{j + 1}. {filtered[j].Name}");

            if (filtered.Count > 0)
            {
                Console.Write($"Choose subclass for {selectedClass.Name}: ");
                int subChoice = int.Parse(Console.ReadLine()) - 1;
                character.Subclasses[selectedClass.Name] = filtered[subChoice];
            }
        }
    }

    public Dictionary<string, int> InputStats()
    {
        var stats = new Dictionary<string, int>();
        foreach (var stat in new[] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" })
        {
            Console.Write($"Enter {stat} score: ");
            stats[stat] = int.Parse(Console.ReadLine());
        }
        return stats;
    }
}
