
namespace MathGame.classes.shared;

public class BaseConsole
{
    public List<string> History { get; } = new();

    public void PressKeyToClear()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public void AddHistoryEntry(string entry)
    {
        History.Add(entry);
    }
}
