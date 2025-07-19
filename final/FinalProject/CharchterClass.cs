using System.Collections.Generic;
using System.Linq;
using System;

public class CharacterClass : GameEntity
{
    public int HitDie { get; set; }
    public string PrimaryStat { get; set; }
    private Dictionary<int, List<Ability>> LevelAbilities { get; set; } = new();

    public CharacterClass(string name, int hitDie, string primaryStat)
    {
        Name = name;
        HitDie = hitDie;
        PrimaryStat = primaryStat;
    }

    public void AddAbility(int level, Ability ability)
    {
        if (!LevelAbilities.ContainsKey(level))
            LevelAbilities[level] = new List<Ability>();
        LevelAbilities[level].Add(ability);
    }

    public List<Ability> GetAbilities(int level)
    {
        return LevelAbilities.Where(pair => pair.Key <= level).SelectMany(pair => pair.Value).ToList();
    }

    public override void Describe()
    {
        Console.WriteLine($"Class: {Name} (Hit Die: d{HitDie}, Primary Stat: {PrimaryStat})");
        Console.WriteLine("Abilities:");
        foreach (var level in LevelAbilities.Keys.OrderBy(l => l))
        {
            foreach (var ab in LevelAbilities[level])
            {
                Console.WriteLine($" - Lv{level} {ab.Name}: {ab.Description}");
            }
        }
    }
}