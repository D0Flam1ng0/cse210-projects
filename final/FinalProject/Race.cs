using System.Collections.Generic;
using System;

public class Race
{
    public string Name { get; set; }
    public Dictionary<string, int> AbilityModifiers { get; set; }
    public List<Ability> Abilities { get; set; }

    // Required for JSON deserialization
    public Race() { }

    public Race(string name, Dictionary<string, int> modifiers, List<Ability> abilities)
    {
        Name = name;
        AbilityModifiers = modifiers;
        Abilities = abilities;
    }
}
