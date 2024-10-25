using CCC_Classic.Utils;

namespace CCC_School_40;

public class AlexLevel1:Level
{
    public override string[] Start(string[] lines)
    {
        var output = new List<string>();
        foreach (var line in lines.Skip(1))
        {

            var splitted = line.Split(" ");
            output.Add(splitted.Select(i=> int.Parse(i)).Sum().ToString());
        }

        return output.ToArray();
    }
}