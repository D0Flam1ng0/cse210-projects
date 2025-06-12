using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        int NapTime = 250;
        Console.WriteLine("Bonjour");
        DateTime currentTime = DateTime.Now;
        int time = 9;
        DateTime endTime = currentTime.AddSeconds(time);
        string animmation = "(-_-)(^_^)";
        string animmation2 = "-+\\|/";
        int index = 0;
        int count = time;
        while (DateTime.Now < endTime)
        {
            Console.Write(animmation2[index++ % animmation2.Length]);
            Thread.Sleep(NapTime);
            Console.Write("\b");
            //Console.WriteLine(count--);
            //Thread.Sleep(1000);
            //Console.WriteLine("\b");
        }
        while (DateTime.Now < endTime)
        {
            //Console.Write("+");
            Console.Write(animmation[0..5]);
            Thread.Sleep(NapTime);
            Console.Write("\b\b\b\b\b");
            Console.Write(animmation[5..]);
            //Console.Write("-");
            Thread.Sleep(NapTime);
            Console.Write("\b\b\b\b\b");

        }
       //Console.WriteLine("Hello Sandbox World!");
       //int x = 10;
       //if (x==10)
       // {
       // Console.WriteLine("x is 10");
       // }
       //for(int i =0; i<x; i++)
       // {
       //  Console.WriteLine($"bob is cool: {i}");
       // }
       // int x = 0;
       //int y =x++;
       //Console.WriteLine(x);
       //Console.WriteLine(y);
       // Circle myCircle = new Circle(10);
       //Circle myCircle2 = new Circle();
       //myCircle.SetRaduis(10);
       //Console.WriteLine($"{myCircle.GetRadius()}");
       //myCircle2.SetRaduis(20);
       //Console.WriteLine($"{myCircle2.GetRadius()}");
       // Console.WriteLine($"{myCircle.GetArea()}");
       //Cylinder myCylinder = new Cylinder();
       //myCylinder.SetCircle(myCircle);
       //myCylinder.SetHeight(10);
       //Console.WriteLine($"{myCylinder.GetVolume()}");
    }
     
}