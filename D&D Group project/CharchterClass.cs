using System.Collections.Generic;
using System.Linq;

public class CharacterClass
{
    public string Name { get; set; }
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
}