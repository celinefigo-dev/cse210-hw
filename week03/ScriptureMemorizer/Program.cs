using System;

public class Program
{
    private ScriptureLibrary scriptureLibrary;
    private Scripture currentScripture;

    public Program()
    {
        scriptureLibrary = new ScriptureLibrary("scriptures.txt");
        currentScripture = scriptureLibrary.GetRandomScripture();
    }

    private void ClearScreen()
    {
        Console.Clear();
    }

    public void Run()
    {
        while (true)
        {
            ClearScreen();
            Console.WriteLine(currentScripture);
            Console.Write("\nPress Enter to hide words or type 'quit' to exit: ");
            var userInput = Console.ReadLine().Trim().ToLower();

            if (userInput == "quit")
            {
                break;
            }

            currentScripture.HideRandomWords();

            if (currentScripture.AllWordsHidden())
            {
                ClearScreen();
                Console.WriteLine(currentScripture);
                Console.WriteLine("\nAll words are now hidden. Great job!");
                break;
            }
        }
    }

    public static void Main(string[] args)
    {
        var program = new Program();
        program.Run();
    }
}

/*
 ---------------------------
 EXCEEDING REQUIREMENTS NOTE:
 ---------------------------
 ✓ Scriptures are loaded from a file ("scriptures.txt").
 ✓ The program supports random scripture selection from a scripture library.
 ✓ Multi-verse references like "Proverbs 3:5-6" are supported.
 ✓ Book names with spaces (e.g., "2 Nephi") are parsed correctly.
*/