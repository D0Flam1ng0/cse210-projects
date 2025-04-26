using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What's your frist name? ");
        string fristName = Console.ReadLine();
        Console.Write("What's your last name? ");
        string LastName = Console.ReadLine();
       
         Console.WriteLine($"your full name is: {LastName}, {fristName} {LastName}.");
    }
}