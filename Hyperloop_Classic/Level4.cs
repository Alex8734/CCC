using CCC_Classic.Utils;
using static CCC_Praktikum2.Level3;
using static CCC_Praktikum2.Level1;
namespace CCC_Praktikum2;

public class Level4:Level
{
    public override string[] Start(string[] lines)
    {
        var locationsCount = int.Parse(lines[0]);
        var locations = GetLocations(lines.Skip(1).Take(locationsCount).ToArray());
        
        var journeys = GetJourneys(lines.Skip(locationsCount + 2).Take(int.Parse(lines[locationsCount + 1])), locations);
        var benefits = int.Parse(lines[^1]);

        
        var hyperLoop = Try4(journeys, locations, benefits);
        var output = hyperLoop.Start.Name + " " + hyperLoop.End.Name;
        
        int fasterJourneys = 0;
        
        foreach (var journey in journeys)
        {
            if(journey.TimeToDrive > CalculateJourneyTime(journey.Start, journey.End, hyperLoop))
            {
                fasterJourneys++;
            }
        }

        Console.WriteLine(output);
        Console.WriteLine($"{fasterJourneys} >= {benefits} ---> {fasterJourneys >= benefits}");
        return [output];
    }
    
    public static HyperLoop Try4(Journey[] journeys, Location[] locations, int benefits)
    {
        HyperLoop bestHyperloop = null;
        int maxBeneficialJourneys = 0;

        for (int i = 0; i < locations.Length; i++)
        {
            for (int j = i + 1; j < locations.Length; j++)
            {
                HyperLoop hyperloop = new HyperLoop( locations[i],locations[j]);
                int countBeneficialJourneys = 0;

                foreach (var journey in journeys)
                {
                    if (journey.TimeToDrive > CalculateJourneyTime(journey.Start, journey.End, hyperloop))
                    {
                        countBeneficialJourneys++;
                    }
                }

                if (countBeneficialJourneys >= benefits && countBeneficialJourneys > maxBeneficialJourneys)
                {
                    maxBeneficialJourneys = countBeneficialJourneys;
                    bestHyperloop = hyperloop;
                }
            }
        }
        return bestHyperloop;
    }
    
    public static HyperLoop Try3(Journey[] journeys, Location[] locations, int benefits)
    {
        var journeyLocations = new List<Location>(journeys.SelectMany(j => new []{j.Start, j.End}));

        var average = new Location()
        {
            Name = "Average",
            X = (int) Math.Round(journeyLocations.Average(l => l.X)),
            Y = (int) Math.Round(journeyLocations.Average(l => l.Y))
        };
        
        var group1 = new List<Location>();
        var group2 = new List<Location>();
        
        foreach (var location in journeyLocations)
        {
            if(location.X < average.X)
            {
                group1.Add(location);
            }
            else
            {
                group2.Add(location);
            }
        }
        
        var averageStart = new Location()
        {
            Name = "AverageStart",
            X = (int) Math.Round(group1.Average(l => l.X)),
            Y = (int) Math.Round(group2.Average(l => l.Y))
        };
        var averageEnd = new Location
        {
            Name = "AverageEnd",
            X = (int) Math.Round(journeys.Select(j => j.End).Average(l => l.X)),
            Y = (int) Math.Round(journeys.Select(j => j.End).Average(l => l.Y))
        };
        
        Location? hyperLoopStart = null;
        Location? hyperLoopEnd = null;

        foreach (var location in locations)
        {
            if(hyperLoopStart == null || 
               location.DistanceTo(averageStart) < hyperLoopStart.DistanceTo(averageStart))
            {
                hyperLoopStart = location;
            }
            if(hyperLoopEnd == null || (
                   location.DistanceTo(averageEnd) < hyperLoopEnd.DistanceTo(averageEnd) && hyperLoopStart != location))
            {
                hyperLoopEnd = location;
            }
        }
        return new HyperLoop(hyperLoopStart, hyperLoopEnd);
    }
    
    public static HyperLoop? Try2(Journey[] journeys, Location[] locations, int benefits)
    {
        var availableLocations = new List<Location>(journeys.SelectMany(j => new []{j.Start, j.End}));
        var groupedLocations = GroupByRadius(500000, availableLocations);
        groupedLocations = groupedLocations.OrderBy(l => l.Count).ToList();
        Console.WriteLine($"{groupedLocations.Count} groups {locations.Length} locations");
        
        var averagePoints = groupedLocations.Select(g => new Location
        {
            Name = "Average",
            X = (int) Math.Round(g.Average(l => l.X)),
            Y = (int) Math.Round(g.Average(l => l.Y))
        }).ToArray();


        List<Location > averageLocations = new();


        foreach (var point in averagePoints)
        {
            Location? average = null;
            
            foreach (var location in locations)
            {
                if(average == null || 
                   location.DistanceTo(point) < average.DistanceTo(point))
                {
                    average = location;
                }
            }
            averageLocations.Add(average);
        }
        
        //TODO: find the best combination of 2 locations
        
        var maxDistance = GetMaxDistance(averageLocations);
        
        return new HyperLoop(maxDistance.start, maxDistance.end);
    }
    
    public static List<List<Location>> GroupByRadius(int radius, List<Location> locations)
    {
        List<List<Location>> groupedLocations = new();
        
        var availableLocations = new List<Location>(locations);

        while (availableLocations.Count > 0)
        {
            var currentLocation = availableLocations.First();
            var currentGroup = new List<Location> {currentLocation};
            availableLocations.Remove(currentLocation);
            var i = 0;
            while (i < availableLocations.Count)
            {
                if (currentLocation.DistanceTo(availableLocations[i]) <= radius)
                {
                    currentGroup.Add(availableLocations[i]);
                    availableLocations.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            groupedLocations.Add(currentGroup);
        }

        return groupedLocations;
    }
    
    public static (Location start, Location end) GetMaxDistance(List<Location> locations)
    {
        double maxDistance = 0;
        Location location1 = null;
        Location location2 = null;

        for (int i = 0; i < locations.Count; i++)
        {
            for (int j = i + 1; j < locations.Count; j++)
            {
                double distance = locations[i].DistanceTo(locations[j]);
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    location1 = locations[i];
                    location2 = locations[j];
                }
            }
        }

        return (location1, location2);
    }
    
    public static HyperLoop Try1(Journey[] journeys, Location[] locations, int benefits)
    {
        
        var averageStart = new Location()
        {
            Name = "AverageStart",
            X = (int) Math.Round(journeys.Select(j => j.Start).Average(l => l.X)),
            Y = (int) Math.Round(journeys.Select(j => j.Start).Average(l => l.Y))
        };
        var averageEnd = new Location
        {
            Name = "AverageEnd",
            X = (int) Math.Round(journeys.Select(j => j.End).Average(l => l.X)),
            Y = (int) Math.Round(journeys.Select(j => j.End).Average(l => l.Y))
        };
        
        Location? hyperLoopStart = null;
        Location? hyperLoopEnd = null;

        foreach (var location in locations)
        {
            if(hyperLoopStart == null || 
               location.DistanceTo(averageStart) < hyperLoopStart.DistanceTo(averageStart))
            {
                hyperLoopStart = location;
            }
            if(hyperLoopEnd == null || (
                   location.DistanceTo(averageEnd) < hyperLoopEnd.DistanceTo(averageEnd) && hyperLoopStart != location))
            {
                hyperLoopEnd = location;
            }
        }
        
        
        return new HyperLoop(hyperLoopStart, hyperLoopEnd);

    }
    
    public static Journey[] GetJourneys(IEnumerable<string> lines, Location[] locations)
    {
        return lines.Select(j =>
        {
            var data = j.Split(" ");
            return new Journey
            {
                Start = locations.First(l => l.Name == data[0]),
                End = locations.First(l => l.Name == data[1]),
                TimeToDrive = int.Parse(data[2])
            };
        }).ToArray();
    }
}