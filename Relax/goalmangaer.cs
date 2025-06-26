using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void RecordActivityEvent(string activityType)
    {
        foreach (Goal goal in _goals)
        {
            if (!goal.IsComplete() && goal.GetActivityType() == activityType)
            {
                int points = goal.RecordEvent();
                if (points > 0)
                {
                    _score += points;
                    Console.WriteLine($"[Goal System] '{goal.GetName()}' progress recorded. +{points} points!");
                }
            }
        }
    }

    public void ShowGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Total Score: {_score}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        _goals.Clear();

        if (!File.Exists(filename))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];

            if (type == "ChecklistGoal")
            {
                ChecklistGoal checklist = new ChecklistGoal(
                    parts[1], // name
                    parts[2], // description
                    int.Parse(parts[3]), // points
                    int.Parse(parts[6]), // targetCount
                    int.Parse(parts[4]), // bonusPoints
                    parts[7]); // activityType

                FieldInfo field = typeof(ChecklistGoal).GetField("_currentCount", BindingFlags.NonPublic | BindingFlags.Instance);
                field?.SetValue(checklist, int.Parse(parts[5]));

                _goals.Add(checklist);
            }
        }
    }
}

