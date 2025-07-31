public class Word
{
    public string Text { get; }
    public bool Hidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    public void Hide()
    {
        Hidden = true;
    }

    public void Reveal()
    {
        Hidden = false;
    }

    public override string ToString()
    {
        return Hidden ? new string('_', Text.Length) : Text;
    }
}