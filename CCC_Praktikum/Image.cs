using System.Net.Mime;

namespace CCC_Praktikum;

public class Image
{
    public int TimeStamp { get; set; }
    public int Rows { get; set; }
    public int Cols { get; set; }
    public int[][] Pixels { get; set; }
    
    public bool[][] Shape { get; set; }
    
    public Image(int timeStamp, int rows, int cols, int[][] pixels)
    {
        TimeStamp = timeStamp;
        Rows = rows;
        Cols = cols;
        Pixels = pixels;
        SetShape();
    }
    
    public bool ShapeEquals (bool[][] shape2)
    {
        if(Shape.Length != shape2.Length || Shape[0].Length != shape2[0].Length)
            return false;
        for (int i = 0; i < Shape.Length; i++)
        {
            for (int j = 0; j < Shape[i].Length; j++)
            {
                if(Shape[i][j] != shape2[i][j])
                    return false;
            }
        }

        return true;
    }
    
    private void SetShape()
    {
        var tempShape = Pixels
            .Select(l => l
                .Select(p => p > 0)
                .ToList())
            .ToList();
        
        //look if row is empty
        int i = 0;
        while (tempShape.Count > i)
        {
            if(tempShape[i].All(p => !p))
            {
                tempShape.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }
        
        //look if col is empty
        int j = 0;
        while (tempShape.Count>0 && tempShape[0].Count > j)
        {
            if(tempShape.All(p => !p[j]))
            {
                foreach (var t in tempShape)
                {
                    t.RemoveAt(j);
                }
            }else
            {
                j++;
            }
        }
        
        Shape = tempShape
            .Where(l => l.Any(d => d))//remove empty rows
            .Select(l => l.ToArray()).ToArray();
    }
    
}