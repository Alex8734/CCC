using CCC_Classic.Utils;
using static CCC_Praktikum.Level1;

namespace CCC_Praktikum;

public class Level2 : Level
{
    public override string[] Start(string[] lines)
    {
        Image[] images = GetImages(lines);

        var matchingShapes = new List<List<Image>>();

        for (int i = 0; i < images.Length; i++)
        {
            if(matchingShapes.Count == 0)
            {
                matchingShapes.Add([images[i]]);
                continue;
            }

            var found = false;
            for (int j = 0; j < matchingShapes.Count; j++)
            {
                if(matchingShapes[j].Count == 0)
                {
                    continue;
                }
                if (matchingShapes[j][0].ShapeEquals(images[i].Shape))
                {
                    matchingShapes[j].Add(images[i]);
                    found = true;
                    break;
                }
            }
            if(!found)
            {
                matchingShapes.Add([images[i]]);
            }
        }

        return matchingShapes
            .Select(s => $"{s.First().TimeStamp} {s.Last().TimeStamp} {s.Count}")
            .ToArray();
    }
    
    
    
    public static Image[] GetImages(string[] lines)
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
        //remove image without meteorites
        return images
            .Where(i => i.Pixels
                .SelectMany(data => data)
                .Any(img => img != 0))
            .ToArray();
    }
}

