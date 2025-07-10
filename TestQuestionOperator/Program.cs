class Program
{
    static void TestByRef(ref int x, ref string n)
    {
        x++;
        n += " this is a string addition";
        Console.WriteLine($"In TestByRef: {x}, {n}");
    }

    static void Main(string[] args)
    {
        int? x = null;
        string? name = null;

        //TestByRef(ref x, ref name);

        //Console.WriteLine($"In main: {x}, {name}");
        //int z;
        //TestByOut(out z);
        //Console.WriteLine($"In Main: {z}");
        int y = x ?? 23;
        Console.WriteLine(y);
        name ??= "betty";
        Console.WriteLine(name);

        string? myName = null;
        int? length = myName?.Length;
        Console.WriteLine(length);

        int bettysAge = 23;
        int bobsAge = 25;

        string whoIsOlder = bettysAge > bobsAge ? "betty is older" : "bob is older";
        Console.WriteLine(whoIsOlder);
    }
    static void TestByOut(out int x)
    {
        x = 120;
        Console.WriteLine($" in TestByOut: {x}");
    }
}

