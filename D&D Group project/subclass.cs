using System.Collections.Generic;
using System.Linq;

public class Subclass
{
    public string Name { get; set; }
    public string ParentClass { get; set; }
    private Dictionary<int, List<Ability>> LevelAbilities { get; set; } = new();

    public Subclass(string name, string parentClass)
    {
        Name = name;
        ParentClass = parentClass;
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