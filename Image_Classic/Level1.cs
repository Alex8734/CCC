using System.Text.RegularExpressions;
using CCC_Classic.Utils;

namespace CCC_Praktikum;

public class Level1 : Level
{
    public override string[] Start(string[] lines)
    {
        var images = new List<Image>();
        int i = 1;
        while (i < lines.Length)
        {
            
            var imgInfo = GetDataFromLine(lines[i]);
            var imgData = GetDataFromLines(lines.Skip(i+1).Take(imgInfo[1]).ToArray());
            var image = new Image(imgInfo[0], imgInfo[1], imgInfo[2],imgData );
            
            images.Add(image);
            i += imgInfo[1] + 1;
        }


        return images
            .Where(i => i.Pixels
                .SelectMany(data => data)
                .Any(img => img != 0))
            .Select(i => i.TimeStamp.ToString())
            .ToArray();
    }
    
    public static int[] GetDataFromLine(string line)
    {
        var data = line.Split(" ");
        return data.Select(i => int.Parse(i)).ToArray();
    }
    public static int[][] GetDataFromLines(string[] lines)
    {
        return lines.Select(GetDataFromLine).ToArray();
    }
    
    
}
