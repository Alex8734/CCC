using CCC_Classic.Utils;
namespace Hyperloop_School;
public class Level1:Level
{
    public override string[] Start(string[] lines)
    {
        var startPoint = new Coordinate(0, 0);
        var separator = int.Parse(lines[0]);
        var coordinates = lines
            .Skip(2).Take(int.Parse(lines[1]))
            .Select(s 
                => new Coordinate(int.Parse(s.Split(" ")[0]),int.Parse(s.Split(" ")[1])));
        var output = new List<string>();

        foreach (var point in coordinates)
        {
            if (point.Y > 0 && point.Y > startPoint.Y || point.Y < 0 && point.Y < startPoint.Y)
            {
                output.Add(point.ToString());
            }
        }

        Console.WriteLine(string.Join(" ",output));
        Console.WriteLine();        
        
        return [string.Join(" ",output)];
    }

    public record Coordinate(int X, int Y)
    {
        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }
}