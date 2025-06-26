using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public override void Run()
    {
        DisplayStartMessage();
        int cycleDuration = 12;
        int elapsed = 0;

        while (elapsed + cycleDuration <= _duration)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountdown(4);
            elapsed += 4;

            Console.WriteLine("\nHold in...");
            ShowCountdown(4);
            elapsed += 4;

            Console.WriteLine("\nBreathe out...");
            ShowCountdown(4);
            elapsed += 4;
        }
        _goalManager?.RecordActivityEvent("Breathing");
        DisplayEndMessage();
    }
}
