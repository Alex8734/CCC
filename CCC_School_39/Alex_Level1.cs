using CCC_Classic.Utils;

namespace CCC_School_39;

public class Alex_Level1:Level
{
    public override string[] Start(string[] lines)
    {
        var output = new List<string>();
        foreach (var line in lines)
        {
            var currency = line.Split(" ").Select(v => new Coin(int.Parse(v))).ToList();
            for (int i = 0; i < currency.Count()-1; i++)
            {
                if (currency.ElementAt(i).Value + 1 != currency.ElementAt(i + 1).Value)
                {
                    output.Add((currency.ElementAt(i).Value +1).ToString());
                    
                }
            }      
        }
        
        return output.ToArray();
    }
}