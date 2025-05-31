using System;
using System.Collections.Generic;

public class Memorizer
{
    private Reference _reference;
    private List<Word> _words;

    public Memorizer(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (var word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        var visibleWords = _words.FindAll(w => !w.IsHidden());

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.TrueForAll(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.ConvertAll(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}: {text}";
    }
}
