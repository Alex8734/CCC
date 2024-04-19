using CCC_Classic.Utils;
using static CCC_Praktikum2.Level1;
using static CCC_Praktikum2.Level2;
namespace CCC_Praktikum2;

public class Level3:Level
{
    
    public override string[] Start(string[] lines)
    {
        var locationsCount = int.Parse(lines[0]);
        var locations = GetLocations(lines.Skip(1).Take(locationsCount).ToArray());
        var loopLocs = lines[^1].Split(" ");
        
        var journesData = lines.Skip(locationsCount + 2).Take(int.Parse(lines[locationsCount + 1]));
        var journeys = journesData.Select(j =>
        {
            var data = j.Split(" ");
            return new Journey
            {
                Start = locations.First(l => l.Name == data[0]),
                End = locations.First(l => l.Name == data[1]),
                TimeToDrive = int.Parse(data[2])
            };
        });
        
        var hyperLoop = new HyperLoop(locations.First(l => l.Name == loopLocs[0]),
            locations.First(l => l.Name == loopLocs[1]));

        int fasterJourneys = 0;
        
        foreach (var journey in journeys)
        {
            if(journey.TimeToDrive > CalculateJourneyTime(journey.Start, journey.End, hyperLoop))
            {
                fasterJourneys++;
            }
        }

        Console.WriteLine(fasterJourneys.ToString());
        return [fasterJourneys.ToString()];
    }
    
    
    public static double CalculateJourneyTime(Location start, Location end, HyperLoop hyperLoop)
    {
        double journeyTime = 0;
        journeyTime += GetShorterDistance(start, hyperLoop) / 15;
        journeyTime += hyperLoop.Time;
        journeyTime += GetShorterDistance(end, hyperLoop) / 15;
        return journeyTime;
    }
}
