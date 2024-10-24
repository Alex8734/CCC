namespace CCC_Classic.Utils;

public static class Extensions
{
    public static void WriteInColor(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public static void WriteInColor(IEnumerable<string> messages, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        foreach (var message in messages)
        {
            Console.WriteLine(message);
        }
        Console.ResetColor();
    }
}