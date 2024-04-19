using CCC_Classic.Utils;

namespace CCC_School_39;

public class Level4:Level
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
            var numParts = parts.Select((val) => int.Parse(val)).ToList();
            
            numParts.Sort((a, b) => b.CompareTo(a));
            int[] valParts = otherParts.Select((val) => int.Parse(val)).ToArray();
            var resultStr = "";

            foreach (var v in valParts)
            {
                var resultnum = v;
                foreach (var num in numParts)
                {
                    int amount = 0;

                    amount = resultnum / num;
                    resultnum -= num * (int)amount;
                    
                    if (amount != 0)
                    {
                        resultStr += $"{amount}x{num} ";
                    }
                }
                res.Add(resultStr);
                resultStr = "";
            }
        }
        return res.ToArray();
    }
   
}