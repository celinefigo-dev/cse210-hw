using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Reference { get; }
    public List<Word> Words { get; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count = 3)
    {
        var visibleWords = Words.Where(word => !word.Hidden).ToList();
        if (!visibleWords.Any()) return;

        var random = new Random();
        var wordsToHide = visibleWords.OrderBy(x => random.Next()).Take(Math.Min(count, visibleWords.Count)).ToList();
        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(word => word.Hidden);
    }

    public override string ToString()
    {
        var scriptureText = string.Join(' ', Words);
        return $"{Reference}\n{scriptureText}";
    }
}