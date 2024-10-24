using System.Text.RegularExpressions;

namespace CCC_Classic.Utils;

public interface ILevel
{
    public string[] Start(string[] lines);
    public void Run(int inputs = 4, bool writeToConsole = false);
    
    public void RunExample();
}

public abstract partial class Level : ILevel
{
    private string Name => GetType().Name;
    
    public abstract string[] Start(string[] lines);
    public void Run( int inputs = 4, bool writeToConsole = false)
    {
        
        Utils.InvokeAllParts(GetLevel(), Start,inputs,writeToConsole);
        Extensions.WriteInColor($"Done with {Name}...",ConsoleColor.Green);
        Console.WriteLine($"Data saved to {Path.GetFullPath($"{Utils.Path}\\{Name}\\")}");
        Console.WriteLine(new string('_', 100));
    }
    
    public void RunExample()
    {
        Utils.InvokeExample(GetLevel(), Start);
    }
    
    private int GetLevel()
    {
        return int.Parse(LevelRegex().Match(Name).Groups[1].Value);

    }

    [GeneratedRegex(@"^.*\D(\d+)")]
    private static partial Regex LevelRegex();
}