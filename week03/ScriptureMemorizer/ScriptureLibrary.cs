using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class ScriptureLibrary
{
    private List<Scripture> scriptures;

    public ScriptureLibrary(string filePath)
    {
        scriptures = new List<Scripture>();
        LoadScripturesFromFile(filePath);
    }

    private void LoadScripturesFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split('|');
            if (parts.Length == 2)
            {
                var referenceText = parts[0].Trim();
                var text = parts[1].Trim();

                var match = System.Text.RegularExpressions.Regex.Match(referenceText, @"^([\w\s]+) (\d+):(\d+)(?:-(\d+))?$");
                if (match.Success)
                {
                    string book = match.Groups[1].Value.Trim();
                    int chapter = int.Parse(match.Groups[2].Value);
                    int verseStart = int.Parse(match.Groups[3].Value);
                    int? verseEnd = match.Groups[4].Success ? int.Parse(match.Groups[4].Value) : (int?)null;

                    var reference = new Reference(book, chapter, verseStart, verseEnd);
                    scriptures.Add(new Scripture(reference, text));
                }
            }
        }
    }

    public Scripture GetRandomScripture()
    {
        var random = new Random();
        return scriptures[random.Next(scriptures.Count)];
    }
}