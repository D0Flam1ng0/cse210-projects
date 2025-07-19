public class Spell
{
    public string Name { get; private set; }
    public int Level { get; private set; }

    public Spell(string name, int level)
    {
        Name = name;
        Level = level;
    }

    public virtual string Cast()
    {
        return $"Casting {Name}!";
    }
}