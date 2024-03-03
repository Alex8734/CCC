using System.Net.Mime;
using CCC_Classic.Utils;
using static CCC_Praktikum.Level2;

namespace CCC_Praktikum;

public class Level3 : Level
{
    public override string[] Start(string[] lines)
    {
        Image[] images = GetImages(lines);
        var matchingShapes = OrderSameShapes(images);
        
        var subsetShapes = new List<List<Image>>();
        
        foreach (var shapes in matchingShapes)
        {
            subsetShapes.AddRange(LookForSubsetOfOneKind(shapes));
        }
       
        return subsetShapes
            .Select(s => $"{s.First().TimeStamp} {s.Last().TimeStamp} {s.Count}")
            .ToArray();
    }
    
    private List<List<Image>> LookForSubsetOfOneKind(List<Image> images)
    {
        var availableImages = new List<Image>(images);
        
        var sameSubsets = new List<List<Image>>();

        int i = 0;
        while (i<availableImages.Count)
        {
            //we look as long as we find a new subset
            int j = i+1;
            while (j < availableImages.Count)
            {
                int curSubset = availableImages[j].TimeStamp - availableImages[i].TimeStamp;
                var curSubsetList = new List<Image> {availableImages[i], availableImages[j]};
                //take all images with the same subset
                foreach (var img in availableImages.Skip(i+1))
                {
                    if(img.TimeStamp - curSubset == curSubsetList.Last().TimeStamp)
                    {
                        curSubsetList.Add(img);
                    }
                }
                //if we found a subset of 4 or more images, we add it to the list
                if(curSubsetList.Count >= 4)
                {
                    sameSubsets.Add(curSubsetList);
                    
                    int c = 0;
                    foreach (var sub in curSubsetList)
                    {
                        if(availableImages.IndexOf(sub) < i)
                        {
                            c++;
                        }
                    }
                    i -= c;
                    
                    availableImages.RemoveAll(img => curSubsetList.Contains(img));
                    break;
                }
                j++;
            }

            //if the first image didn't got deleted, we go to the next one
            if(sameSubsets.Count > 0 && availableImages.Count > 0 && sameSubsets.Last()[0] == availableImages[i])
                i++;
        }

        return sameSubsets;
    }
    
    public List<List<Image>> OrderSameShapes(Image[] images)
    {
        
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

        return matchingShapes;
    }
}