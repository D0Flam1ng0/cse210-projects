using System;

class Program
{
    static GoalManager goalManager = new GoalManager();

    static void Main(string[] args)
    {
        // Initialize default activity goals
        goalManager.AddGoal(new ChecklistGoal("Breathe 5 Times", "Complete 5 Breathing sessions", 3, 5, 10, "Breathing"));
        goalManager.AddGoal(new ChecklistGoal("List 3 Times", "Complete 3 Listing sessions", 2, 3, 5, "Listing"));
        goalManager.AddGoal(new ChecklistGoal("Reflect 4 Times", "Complete 4 Reflection sessions", 4, 4, 8, "Reflection"));

        goalManager.LoadGoals("goals.txt");

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Relaxation & Progress Tracker");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflection Activity");
            Console.WriteLine("4. View Progress");
            Console.WriteLine("5. Save Progress");
            Console.WriteLine("6. Load Progress");
            Console.WriteLine("7. Exit");

            Console.Write("\nSelect an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunActivity(new BreathingActivity(), "Breathing");
                    break;
                case "2":
                    RunActivity(new ListingActivity(), "Listing");
                    break;
                case "3":
                    RunActivity(new ReflectionActivity(), "Reflection");
                    break;
                case "4":
                    goalManager.ShowGoals();
                    goalManager.ShowScore();
                    Pause();
                    break;
                case "5":
                    goalManager.SaveGoals("goals.txt");
                    Console.WriteLine("Progress saved!");
                    Pause();
                    break;
                case "6":
                    goalManager.LoadGoals("goals.txt");
                    Console.WriteLine("Progress loaded!");
                    Pause();
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    Pause();
                    break;
            }
        }
    }

    static void RunActivity(Activity activity, string activityType)
    {
        Console.Write("Duration in seconds: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int duration))
        {
            activity.SetDuration(duration); // You must have SetDuration(int) in Activity.cs
            activity.SetGoalManager(goalManager); // You must add this method to Activity.cs
            activity.Run();

            // No need to call this here if you already call it in Run()
            // goalManager.RecordActivityEvent(activityType);
        }
        else
        {
            Console.WriteLine("Invalid duration.");
        }

        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}



