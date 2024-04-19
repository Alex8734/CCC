namespace CCC_Praktikum2;

public class Location
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    
    public double DistanceTo(Location other) => 
        Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
    
    public override string ToString()
    {
        return $"{Name} ({X},{Y})";
    }
}

public class HyperLoop
{
    public HyperLoop(Location start, Location end)
    {
        Start = start;
        End = end;
    }

    public Location Start { get; set; }
    public Location End { get; set; }
    public double Distance => Start.DistanceTo(End);
    public double Time => Distance / 250 + 200;

    public override string ToString()
    {
        return $"{Start.Name}-{End.Name} : {Time}";
    }
}

public class HyperLoop2
{
    public HyperLoop2(List<Location> locations)
    {
        Locations = locations;
    }

    public List<Location> Locations { get; set; }
    public double Distance => Locations[0].DistanceTo(Locations[^1]);
    public double Time => Distance / 250 + 200;
    
    
    
}


public class Journey
{
    public Location Start { get; set; }
    public Location End { get; set; }
    public int TimeToDrive { get; set; }
    public override string ToString()
    {
        return $"{Start.Name}-{End.Name} : {TimeToDrive}";
    }
}