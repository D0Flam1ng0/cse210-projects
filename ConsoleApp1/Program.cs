class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("Proverbs 3:5–6");
        var scripture = new Memorizer(reference, "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");

        while (!scripture.AllWordsHidden())
        {
            SafeClear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit':");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords(3);
        }

        Console.WriteLine("\nAll words hidden!");
    }
    static void SafeClear()
    {
        try
        {
            Console.Clear();
        }
        catch (System.IO.IOException)
        {
            // Ignore if can't clear console
        }
    }
}