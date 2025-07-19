public class Warlock : Character
{
    public Warlock(string name, int level) : base(name, level) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Warlock: {Name}, Level: {Level}");
    }
}
public class Wizard : Character
{
    public Wizard(string name, int level) : base(name, level) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Wizard: {Name}, Level: {Level}");
    }
}
public class Gunmage : Character
{
    public Gunmage(string name, int level) : base(name, level) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Gunmage: {Name}, Level: {Level}");
    }
}