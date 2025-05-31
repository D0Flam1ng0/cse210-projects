class WordCounter
{

    private List<string> _words;

    public WordCounter(string text)
    {
        _words = new List<string>();
        SpiltTextIntoWords(text);

    }
    private void SpiltTextIntoWords(string text)
    {
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(word);
        }
    }
    public void Displaywords()
    {
        foreach (string word in _words)
        {
            Console.WriteLine(word);
        }
    }

    public int countSingleWord(string searchWord)
    {
        int count = 0;
        foreach (string word in _words)
        {
            if (word == searchWord)
                count++;
        }
        return count;
    }
}