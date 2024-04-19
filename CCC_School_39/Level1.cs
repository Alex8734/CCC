using CCC_Classic.Utils;

namespace CCC_School_39;

public class Level1 : Level
{
    public override string[] Start(string[] lines)
    {
        int n = int.Parse(lines[0]);
        int countOfCurrency = int.Parse(lines[1]);
        List<int> res = new List<int>();

        for (int i = 2; i < lines.Length; i ++)
        {
            string[] parts = lines[i].Split(" ");
            int[] numParts = parts.Select((val) => int.Parse(val)).ToArray();
            for (int j = 1; true; j++)
            {
                bool found = false;
                foreach (int v in numParts)
                {
                    if (j == v)
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    res.Add(j);
                    break;
                }
            }
        }
        return res.Select(v => v.ToString()).ToArray();
    }
}