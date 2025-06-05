class Program
{

    public static void Main(string[] args)
    {
        Person myPerson = new Person("John", "Nob", 23);

        Console.WriteLine(myPerson.GetPersonInfo());

        PoliceMan MyPoliceman = new PoliceMan("Cooper", "Silver", 34, "Shotgun");
        Console.WriteLine(MyPoliceman.GetPersonInfo());
        Doctor MyDoctor = new Doctor("Bob", "James", 34, "Syringe");
        Console.WriteLine(MyDoctor.GetPersonInfo());
    }
}
