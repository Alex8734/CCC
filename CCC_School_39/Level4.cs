using CCC_Classic.Utils;

namespace CCC_School_39;

public class Alex_Level4:Level
{
    public override string[] Start(string[] lines)
    {
        var output = new List<string>();
        for (var j = 3; j<lines.Length-1; j+=2)
        {
            var currency = lines[j].Split(" ").Select(v => int.Parse(v)).ToList();
            var amounts =  lines[j+1].Split(" ").Select(v => int.Parse(v)).ToList();
            foreach (var amount in amounts)
            {
                output.Add(MinCoins(currency.ToArray(),amount).Select(kv => $"{kv.Value}x{kv.Key}").Aggregate((a,b) => $"{a} {b}")?? "");
                Console.WriteLine($"got {output.Count}");
            }

            
        }
        return output.ToArray();
    }
    public Dictionary<int, int> MinCoins(int[] coins, int amount)
    {
        var queue = new Queue<(int, Dictionary<int, int>)>();
        var visited = new HashSet<int>();
        queue.Enqueue((0, new Dictionary<int, int>()));

        while (queue.Count > 0)
        {
            var (currentAmount, coinCount) = queue.Dequeue();

            if (currentAmount == amount)
            {
                return coinCount;
            }

            foreach (var coin in coins)
            {
                var newAmount = currentAmount + coin;

                if (newAmount <= amount && !visited.Contains(newAmount))
                {
                    var newCoinCount = new Dictionary<int, int>(coinCount);

                    if (newCoinCount.ContainsKey(coin))
                    {
                        newCoinCount[coin]++;
                    }
                    else
                    {
                        newCoinCount[coin] = 1;
                    }

                    queue.Enqueue((newAmount, newCoinCount));
                    visited.Add(newAmount);
                }
            }
        }

        return null;
    }
   
}