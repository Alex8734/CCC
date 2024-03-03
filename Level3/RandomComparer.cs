namespace Level3;

public class RandomComparer : IComparer<string>
{
    
    public int Compare(string x, string y)
    {
        var rnd = new Random();
        return 0.5 - rnd.NextDouble() > 0 ? 1 : -1;
    }
}