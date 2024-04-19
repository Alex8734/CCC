using CCC_Classic.Utils;

namespace CCC_Praktikum2;

public class Level1: Level
{
    public override string[] Start(string[] lines)
    {
        var locations = GetLocations(lines.Skip(1).Take(lines.Length - 2).ToArray());
        var loopLocs = lines[^1].Split(" ");
        var hyperLoop = new HyperLoop(locations.First(l => l.Name == loopLocs[0]),
            locations.First(l => l.Name == loopLocs[1]));
        
        var output = Math.Round(hyperLoop.Time).ToString();
        Console.WriteLine(output);
        return [output];
    }

    public static Location[] GetLocations(string[] lines)
    {
        var locations = new List<Location>();
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            locations.Add(new Location
            {
                Name = parts[0],
                X = int.Parse(parts[1]),
                Y = int.Parse(parts[2])
            });
        }
        return locations.ToArray();
    }
}

