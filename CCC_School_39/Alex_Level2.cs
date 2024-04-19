using CCC_Classic.Utils;

namespace CCC_School_39;

public class Alex_Level2:Level
{
    public override string[] Start(string[] lines)
    {
        var output = new List<string>();
        for (int i = 3; i < lines.Length; i+=2)
        {
            var currency = lines[i].Split(" ").Select(v => int.Parse(v)).ToList();
            var amounts =  lines[i+1].Split(" ").Select(v => int.Parse(v)).ToList();

            foreach (var amount in amounts)
            {
                foreach (var coin in currency)
                {
                    foreach (var coin2 in currency)
                    {
                        if (amount == coin + coin2)
                        {
                            output.Add($"{coin} {coin2}");
                        }
                    }
                }
                
            }
            
        }

        return output.ToArray();
    }
}