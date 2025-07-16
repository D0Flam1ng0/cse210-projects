using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class CharacterManager
{
    private const string SavePath = "characters.json";
    public List<Character> Characters { get; private set; } = new();

    public void SaveCharacter(Character character)
    {
        Characters.Add(character);
        File.WriteAllText(SavePath, JsonSerializer.Serialize(Characters));
    }

    public void LoadCharacters()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            Characters = JsonSerializer.Deserialize<List<Character>>(json) ?? new List<Character>();
        }
    }

    public void DisplayCharacterList()
    {
        for (int i = 0; i < Characters.Count; i++)
        {
            var c = Characters[i];
            Console.WriteLine($"{i + 1}. {c.Name} (Level {c.Level} {c.Race.Name} - {string.Join(", ", c.Classes.Select(cl => cl.Name))})");
        }
    }

    public void ViewCharacterDetails(int index)
    {
        if (index >= 0 && index < Characters.Count)
        {
            Characters[index].DisplaySheet();
        }
    }
}