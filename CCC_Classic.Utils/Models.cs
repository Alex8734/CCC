using System.Text.RegularExpressions;

namespace CCC_Classic.Utils;

public interface ILevel
{
    public string[] Start(string[] lines);
    public void Run();
    public void RunExample();
}

public abstract partial class Level : ILevel
{
    private string Name => GetType().Name;
    
    public abstract string[] Start(string[] lines);
    public void Run()
    {
        
        Utils.InvokeAllParts(GetLevel(), Start);
        Console.WriteLine($"Done with {Name}...");
        Console.WriteLine($"Data saved to {Environment.CurrentDirectory}\\Data\\{Name}\\");
        Console.WriteLine(new string('_', 100));
    }
    public void RunExample()
    {
        Utils.InvokeExample(GetLevel(), Start);
    }
    
    private int GetLevel()
    {
        return int.Parse(MyRegex().Match(Name).Groups[1].Value);

    }

    [GeneratedRegex(@"^.*\D(\d+)")]
    private static partial Regex MyRegex();
}