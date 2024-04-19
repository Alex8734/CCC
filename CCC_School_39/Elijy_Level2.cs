using CCC_Classic.Utils;

namespace CCC_School_39;

public class Elija_Level2 : Level
{
    public override string[] Start(string[] lines)
    {
        var output = new List<Coin>();
        int currencies = int.Parse(lines[0]);
        int coinsper = int.Parse(lines[1]);
        int amountsper = int.Parse(lines[2]);

        var res = new List<string>();
        for (int i = 3; i < lines.Length ; i++)
        {
            List<int> amounts = new List<int>();
            List<Coin> currency = new List<Coin>();
            if (i % 2 == 0)
            {
                amounts = lines[i].Split(' ').Select(int.Parse).ToList();
            }
            else
            {
                currency = lines[i].Split(' ').Select(v => new Coin(int.Parse(v))).ToList();
            }

            foreach (var am in amounts)
            {
                bool found = false;
                for (int j = 0; j < currency.Count; j++)
                {
                    for (int k = 0; k < currency.Count; k++)
                    {
                        if (currency[j].Value + currency[k].Value == am)
                        {
                            res.Add($"{currency[j].Value} {currency[k].Value}");
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        break;
                    }
                }
            }
        }

        return res.ToArray();
    }
}