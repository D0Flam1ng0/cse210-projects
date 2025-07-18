using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life. Imagine a blank room to start:")
    { }

    public override void Run()
    {
        DisplayStartMessage();
        Console.WriteLine("\n" + _prompts[_random.Next(_prompts.Count)]);

        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.WriteLine("\n" + _questions[_random.Next(_questions.Count)]);
            ShowSpinner(5);
            elapsed += 5;
        }
        _goalManager?.RecordActivityEvent("Reflection");
        DisplayEndMessage();
    }
}
