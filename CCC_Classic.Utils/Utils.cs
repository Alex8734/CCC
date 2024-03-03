namespace CCC_Classic.Utils;

public class Utils
{
    public static void InvokeAllParts(int lvl, Func<string[],string[]> f, int inputs = 5)
    {
        for (int i = 0; i < inputs; i++)
        {
            var data =File.ReadAllLines($"Data/Level{lvl}/lvl{lvl}_{i}.inp");
            var output = f.Invoke(data);
            File.WriteAllLines($"Data/level{lvl}/level{lvl}_{i}.out", output);
        }
    }
    
    public static void InvokeExample(int lvl, Func<string[],string[]> f )
    {
        var data =File.ReadAllLines($"Data/Level{lvl}/level{lvl}_example.in");
        var output = f.Invoke(data);
        
        var expected = File.ReadAllLines($"Data/Level{lvl}/level{lvl}_example.out");
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
        
        File.WriteAllLines($"Data/level{lvl}/level{lvl}_example.out2", output);
        Console.WriteLine($@"Saved output to {Environment.CurrentDirectory}\Data\Level{lvl}\level{lvl}_example.out2");
    }
}