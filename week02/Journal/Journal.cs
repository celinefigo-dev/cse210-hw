using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
        Console.WriteLine("Journal saved to JSON file.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string json = File.ReadAllText(filename);
        _entries = JsonSerializer.Deserialize<List<Entry>>(json);
        Console.WriteLine("Journal loaded from JSON file.");
    }

    public void SearchEntries(string keyword)
    {
        var results = _entries.Where(e =>
            e.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            e.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (!results.Any())
        {
            Console.WriteLine("No matching entries found.");
            return;
        }

        Console.WriteLine("\nMatching entries:");
        foreach (var entry in results)
        {
            Console.WriteLine(entry);
        }
    }
}

