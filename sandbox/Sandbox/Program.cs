using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bonjour");
       //Console.WriteLine("Hello Sandbox World!");
       //int x = 10;
       //if (x==10)
       {
       // Console.WriteLine("x is 10");
       }
       //for(int i =0; i<x; i++)
       {
          //  Console.WriteLine($"bob is cool: {i}");
       }
       // int x = 0;
        //int y =x++;
        //Console.WriteLine(x);
        //Console.WriteLine(y);
        Circle myCircle = new Circle();
        Circle myCircle2 = new Circle();
        myCircle.SetRaduis(10);
        Console.WriteLine($"{myCircle.GetRadius()}");
        myCircle2.SetRaduis(20);
        Console.WriteLine($"{myCircle2.GetRadius()}");
        Console.WriteLine($"{myCircle2.GetArea()}");
        Cylinder myCylinder = new Cylinder();
        myCylinder.SetCircle(myCircle);
        myCylinder.SetHeight(10);
        Console.WriteLine($"{myCylinder.GetVolume()}");
    }
     
}