using System;
using System.Collections.Generic;
using System.Linq;

public class Character
{
    public string Name { get; set; }
    public int Level { get; set; }
    public Race Race { get; set; }
    public List<CharacterClass> Classes { get; set; } = new();
    public Dictionary<string, Subclass> Subclasses { get; set; } = new();
    public Dictionary<string, int> AbilityScores { get; set; } = new();

    public List<Ability> GetAllAbilities()
    {
        List<Ability> allAbilities = new();
        if (Race != null) allAbilities.AddRange(Race.Abilities);
        foreach (var c in Classes)
        {
            allAbilities.AddRange(c.GetAbilities(Level));
            if (Subclasses.ContainsKey(c.Name))
                allAbilities.AddRange(Subclasses[c.Name].GetAbilities(Level));
        }
        return allAbilities;
    }

    public void DisplaySheet()
    {
        Console.WriteLine($"\n--- {Name}'s Character Sheet ---");
        Console.WriteLine($"Race: {Race.Name}");
        Console.WriteLine($"Level: {Level}");

        Console.WriteLine("\nClasses:");
        foreach (var c in Classes)
        {
            string sub = Subclasses.ContainsKey(c.Name) ? $" ({Subclasses[c.Name].Name})" : "";
            Console.WriteLine($"- {c.Name}{sub}");
        }

        Console.WriteLine("\nAbility Scores:");
        foreach (var score in AbilityScores)
        {
            int bonus = Race.AbilityModifiers.GetValueOrDefault(score.Key, 0);
            Console.WriteLine($"{score.Key}: {score.Value + bonus}");
        }

        Console.WriteLine("\nAbilities:");
        foreach (var ability in GetAllAbilities())
        {
            Console.WriteLine($"- {ability.Name}: {ability.Description}");
        }
    }
}