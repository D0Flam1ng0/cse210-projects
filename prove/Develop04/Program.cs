using System;

class Program
{
    static void Main(string[] args)
    {
        Assignments myAssignments = new Assignments("Samuel", "Bennett", "Multiplication");
        Console.WriteLine(myAssignments.GetAssignmentsInfo());
        Math MyMath = new Math("Roberto", "Rodriguez", "Fractions", "Section 7.3 Problems 8-19");
        Console.WriteLine(MyMath.GetMathInfo());
        English MyEnglish = new English("Mary", "Waters", "European History", "The Causes of World War II by Mary Waters");
        Console.WriteLine(MyEnglish.GetEnglishInfo());
    }
}
