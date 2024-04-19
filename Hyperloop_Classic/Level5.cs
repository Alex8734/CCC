using CCC_Classic.Utils;
using static CCC_Praktikum2.Level1;
namespace CCC_Praktikum2;

public class Level5:Level
{
    public override string[] Start(string[] lines)
    {
        var locations = GetLocations(lines.Skip(1).Take(lines.Length - 3).ToArray());
        var loopLocs = lines[^1].Split(" ").Skip(1).ToArray();
        var travelLocs = lines[^2].Split(" ");
            
        var journeyStart = locations.First(l => l.Name == travelLocs[0]);
        var journeyEnd = locations.First(l => l.Name == travelLocs[1]);
        
        var loopLocations = new List<Location>();
        foreach (var loc in loopLocs)
        {
            loopLocations.Add(locations.First(l => l.Name == loc));
        }

        var hyperLoop = new HyperLoop2(loopLocations);

        double journeyTime = 0;
        return [];
        /*
        journeyTime += GetShortestDistance(journeyStart, null) / 15;
        journeyTime += hyperLoop.Time;
        journeyTime += GetShortestDistance(journeyEnd, hyperLoop) / 15;
        
        var output = Math.Round(journeyTime).ToString();
        Console.WriteLine(output);
        return [output];*/
    }
    
    public static double GetShortestDistance(Location start, HyperLoop hyperLoop)
    {
        return start.DistanceTo(hyperLoop.Start) < start.DistanceTo(hyperLoop.End) 
            ? start.DistanceTo(hyperLoop.Start) 
            : start.DistanceTo(hyperLoop.End);
    }
}