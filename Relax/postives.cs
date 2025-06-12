using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "What fun actives done by yourself or with others?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area. Imagine a blank room to start:")
    { }

    public override void Run()
    {
        DisplayStartMessage();

        Console.WriteLine("\n" + _prompts[_random.Next(_prompts.Count)]);
        Console.WriteLine("You have a few seconds to think...");
        ShowCountdown(5);

        Console.WriteLine("\nStart listing items (press Enter after each):");
        List<string> items = new List<string>();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < _duration)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            // Optional safety: break if time expired while user was typing
            if (stopwatch.Elapsed.TotalSeconds >= _duration)
                break;

            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");
        DisplayEndMessage();
    }
}