using System;
using System.Collections.Generic;

public class CharacterBuilder
{
    public Character BuildCharacter()
    {
        Character character = new Character();

        Console.Write("Enter character name: ");
        character.Name = Console.ReadLine();

        character.Race = ChooseRace();
        character.Class = ChooseClass();
        character.Subclass = ChooseSubclass(character.Class);

        Console.Write("Enter level (1-20): ");
        character.Level = int.Parse(Console.ReadLine());

        character.AbilityScores = InputStats();

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

    public CharacterClass ChooseClass()
    {
        var rogue = new CharacterClass("Rogue", 8, "Dexterity");
        rogue.AddAbility(1, new Ability("Sneak Attack", "Bonus damage"));
        rogue.AddAbility(2, new Ability("Cunning Action", "Bonus action to dash, disengage, or hide"));

        Console.WriteLine("Choose Class: 1. Rogue (default)");
        return rogue;
    }

    public Subclass ChooseSubclass(CharacterClass chosenClass)
    {
        var assassin = new Subclass("Assassin");
        assassin.AddAbility(3, new Ability("Assassinate", "Advantage on surprised enemies"));

        Console.WriteLine("Choose Subclass: 1. Assassin (default)");
        return assassin;
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