namespace CCC_Classic.Utils;
using System.IO;

public class Utils
{
    public static Func<int,int,string> FileSelector { get; set; } = (l, i) => $"level{l}_{i}.in";
    public static Func<int,string> ExampleSelector { get; set; } = (l) => $"level{l}_example.in";
    public static Func<int,string> ExampleOutSelector { get; set; } = (l) => $"level{l}_example.out";
    public static string Path { get; set; } = "../../../Data";
    public static int StartIdx { get; set; } = 1;
    
    public static void InvokeAllParts(int lvl, Func<string[],string[]> f, int inputs = 4,  bool writeToConsole = false)
    {
        
        for (int i = StartIdx; i < inputs+StartIdx; i++)
        {
            var data =File.ReadAllLines($"{Path}/Level{lvl}/{FileSelector.Invoke(lvl,i)}");
            var output = f.Invoke(data);
            if(writeToConsole)
            {
                Console.WriteLine($"Output for level {lvl} input {i}:");
                foreach (var s in output)
                {
                    Console.WriteLine(s);
                }
            }
            File.WriteAllLines($"{Path}/Level{lvl}/level{lvl}_{i}.out", output);
        }
    }
    public static void InvokeExample(int lvl, Func<string[],string[]> f)
    {
        var data =File.ReadAllLines($"{Path}/Level{lvl}/{ExampleSelector.Invoke(lvl)}");
        var output = f.Invoke(data);
        
        var expected = File.ReadAllLines($"{Path}/Level{lvl}/{ExampleOutSelector.Invoke(lvl)}");
        var isCorrect = true;
        if(output.Length != expected.Length)
        {
            Console.Write($"Expected: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{expected.Length} lines");
            Console.ResetColor();
            Console.Write("Got: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{output.Length} lines");
            Console.ResetColor();
            isCorrect = false;
        }
        for (int i = 0; i < output.Length; i++)
        {
            if (output[i] != expected[i])
            {
                Console.Write($"Expected: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{expected[i]}");
                Console.ResetColor();
                Console.Write("Got: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{output[i]}");
                Console.ResetColor();
                isCorrect = false;
            }
        }
        
        if(isCorrect)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Everything is correct!");
            Console.ResetColor();
        }
        var outPath =System.IO.Path.GetFullPath($"{Path}/Level{lvl}/level{lvl}_example.out2");
        File.WriteAllLines(outPath, output);
        Console.WriteLine($@"Saved output to {outPath}");
    }
}