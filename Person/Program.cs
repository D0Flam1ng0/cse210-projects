class Program
{

    public static void Main(string[] args)
    {
        //Person myPerson = new Person("John", "Nob", 23);

        PoliceMan MyPoliceman = new PoliceMan("Cooper", "Silver", 34, "Shotgun", 56, 20);
        Doctor MyDoctor = new Doctor("Bob", "James", 34, "Syringe",450000);
        
        List<Person> myPeople = new List<Person>();
        //myPeople.Add(myPerson);
        myPeople.Add(MyDoctor);
        myPeople.Add(MyPoliceman);

        foreach (Person person in myPeople)
        {
            DisplayPersonInfo(person);
        }
    }
    private static void DisplayPersonInfo(Person person)
    {
        Console.Write(person.GetPersonInfo());
        Console.WriteLine($"    Salaray: {person.getSalary()}");
    }
}
