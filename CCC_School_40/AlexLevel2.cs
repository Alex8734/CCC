using CCC_Classic.Utils;

namespace CCC_School_40.Data;

public class AlexLevel2 : Level
{
    public override string[] Start(string[] lines)
    {
        var output = new List<string>();
        foreach (var line in lines.Skip(1))
        {
            var currentVel = 0;
            var heigth = 0;
            var ints = line.Split(" ").Select(i => int.Parse(i));
            for (int i = 0; i < ints.Count(); i++)
            {
                currentVel = ints.ElementAt(i) - 10 + currentVel;
                heigth += currentVel;
                if (heigth < 0) heigth = 0;
            }
            output.Add(heigth.ToString());
        }

        return output.ToArray();
    }
}