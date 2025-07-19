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

        var warlock = new CharacterClass("Warlock", 8, "Charisma");
        warlock.AddAbility(1, new Ability("Eldritch Invocations", "Gain magical traits"));
        warlock.AddAbility(2, new Ability("Pact Magic", "Spellcasting based on Charisma"));
        AvailableClasses.Add(warlock);

        var fiend = new Subclass("Fiend Patron", "Warlock");
        fiend.AddAbility(3, new Ability("Dark One's Blessing", "Gain temp HP when you reduce a creature to 0 HP"));
        AvailableSubclasses.Add(fiend);

        var gunmage = new CharacterClass("Gunmage", 10, "Intelligence");
        gunmage.AddAbility(1, new Ability("Arcane Shot", "Fire magic-infused bullets"));
        gunmage.AddAbility(2, new Ability("Runed Gun", "Customizable arcane firearm"));
        AvailableClasses.Add(gunmage);

        var arcstriker = new Subclass("Arcstriker", "Gunmage");
        arcstriker.AddAbility(3, new Ability("Arc Surge", "Explosive energy shot that deals AoE damage"));
        AvailableSubclasses.Add(arcstriker);
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

         var human = new Race("Human",
        new Dictionary<string, int>
        {
            { "Strength", 1 }, { "Dexterity", 1 }, { "Constitution", 1 },
            { "Intelligence", 1 }, { "Wisdom", 1 }, { "Charisma", 1 }
        },
        
        new List<Ability> { new("Versatile", "Gain a bonus feat at level 1") });
        var dwarf = new Race("Dwarf",
       new Dictionary<string, int> { { "Constitution", 2 }, { "Wisdom", 1 } },
       new List<Ability>
       {
            new("Darkvision", "See in dark"),
            new("Dwarven Resilience", "Advantage on saves vs poison")
       });

        var scarecrow = new Race("Scarecrow",
            new Dictionary<string, int> { { "Charisma", 2 }, { "Wisdom", 1 } },
            new List<Ability>
            {
            new("Frightening Presence", "Can attempt to frighten nearby enemies once per short rest"),
            new("Stuffed Form", "Immune to poison and disease"),
            new("Silent Watcher", "Does not need to sleep; keeps watch during rest")
            });
        List<Race> races = new() { elf, human, dwarf, scarecrow };

    Console.WriteLine("Choose Race:");
    for (int i = 0; i < races.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {races[i].Name}");
    }

    Console.Write("Enter choice: ");
    if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= races.Count)
    {
        return races[choice - 1];
    }

    Console.WriteLine("Invalid input. Defaulting to Elf.");
    return elf;
    }

  public void ChooseClassesAndSubclasses(Character character)
{
    int totalLevel = character.Level;
    int allocatedLevels = 0;

    Console.WriteLine("How many different classes do you want to take?");
    int classCount = int.Parse(Console.ReadLine());

    for (int i = 0; i < classCount; i++)
    {
        Console.WriteLine("Available Classes:");
        for (int j = 0; j < AvailableClasses.Count; j++)
            Console.WriteLine($"{j + 1}. {AvailableClasses[j].Name}");

        Console.Write($"Choose class #{i + 1}: ");
        int classChoice = int.Parse(Console.ReadLine()) - 1;
        var selectedClass = AvailableClasses[classChoice];

        int levelForClass;
        while (true)
        {
            Console.Write($"Enter number of levels for {selectedClass.Name} (Remaining: {totalLevel - allocatedLevels}): ");
            levelForClass = int.Parse(Console.ReadLine());

            if (levelForClass > 0 && allocatedLevels + levelForClass <= totalLevel)
                break;

            Console.WriteLine("Invalid level amount. Try again.");
        }

        allocatedLevels += levelForClass;

        // Create a shallow copy of the class with abilities scaled to the level
        CharacterClass leveledClass = new CharacterClass(selectedClass.Name, selectedClass.HitDie, selectedClass.PrimaryStat);
        for (int level = 1; level <= levelForClass; level++)
        {
            foreach (var ab in selectedClass.GetAbilities(level))
                leveledClass.AddAbility(level, ab);
        }

        character.Classes.Add(leveledClass);

        // Handle Subclasses
        List<Subclass> filtered = AvailableSubclasses.FindAll(s => s.ParentClass == selectedClass.Name);
        if (filtered.Count > 0)
        {
            Console.WriteLine("Available Subclasses:");
            for (int j = 0; j < filtered.Count; j++)
                Console.WriteLine($"{j + 1}. {filtered[j].Name}");

            Console.Write($"Choose subclass for {selectedClass.Name}: ");
            int subChoice = int.Parse(Console.ReadLine()) - 1;
            character.Subclasses[selectedClass.Name] = filtered[subChoice];
        }

        if (allocatedLevels == totalLevel)
            break;
    }

    if (allocatedLevels < totalLevel)
    {
        Console.WriteLine($"\nYou still have {totalLevel - allocatedLevels} unassigned levels. Consider redistributing your multiclassing.");
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
