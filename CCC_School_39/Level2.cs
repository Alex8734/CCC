using CCC_Classic.Utils;

namespace CCC_School_39;

public class Level2:Level
{
    public override string[] Start(string[] lines)
    {
        int n = int.Parse(lines[0]);
        int countOfCurrency = int.Parse(lines[1]);
        int numOfAmount = int.Parse(lines[2]);
        List<string> res = new List<string>();

        for (int i = 3; i < lines.Length; i += 2)
        {
            string[] parts = lines[i].Split(" ");
            string[] otherParts = lines[i+1].Split(" ");
            int[] numParts = parts.Select((val) => int.Parse(val)).ToArray();
            int[] valParts = parts.Select((val) => int.Parse(val)).ToArray();

            foreach (var v in valParts)
            {
                foreach (var num in numParts)
                {
                    foreach (var num2 in numParts)
                    {
                        if (num2 + num == v)
                        {
                            res.Add($"{num} {num2}");
                        }
                    }
                }
            }
            
        }
        return res.ToArray();
    }
}