using CCC_Classic.Utils;
using static CCC_Praktikum2.Level1;
namespace CCC_Praktikum2;

public class Level2:Level
{
    public override string[] Start(string[] lines)
    {
        var locations = GetLocations(lines.Skip(1).Take(lines.Length - 3).ToArray());
        var loopLocs = lines[^1].Split(" ");
        var travelLocs = lines[^2].Split(" ");
            
        var journeyStart = locations.First(l => l.Name == travelLocs[0]);
        var journeyEnd = locations.First(l => l.Name == travelLocs[1]);
        
        var hyperLoop = new HyperLoop(locations.First(l => l.Name == loopLocs[0]),
            locations.First(l => l.Name == loopLocs[1]));

        double journeyTime = 0;
        
        journeyTime += GetShorterDistance(journeyStart, hyperLoop) / 15;
        journeyTime += hyperLoop.Time;
        journeyTime += GetShorterDistance(journeyEnd, hyperLoop) / 15;
        
        var output = Math.Round(journeyTime).ToString();
        Console.WriteLine(output);
        return [output];
    }
    
    public static double GetShorterDistance(Location start, HyperLoop hyperLoop)
    {
        return start.DistanceTo(hyperLoop.Start) < start.DistanceTo(hyperLoop.End) 
            ? start.DistanceTo(hyperLoop.Start) 
            : start.DistanceTo(hyperLoop.End);
    }
}