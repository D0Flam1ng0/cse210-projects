using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected GoalManager _goalManager;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"\n--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("Enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public void SetGoalManager(GoalManager manager)
    {
        _goalManager = manager;
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };
        int endTime = Environment.TickCount + (seconds * 1000);
        int i = 0;
        while (Environment.TickCount < endTime)
        {
            Console.Write(symbols[i % symbols.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}... ");
            Thread.Sleep(1000);
            Console.Write("\r" + new string(' ', 10) + "\r");
        }
    }

    public abstract void Run();
}
