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
                output.Add(MinCoins(currency.ToArray(),amount).Item2?.Select(kv => $"{kv.Value}x{kv.Key}").Aggregate((a,b) => $"{a} {b}")?? "");
            }
        }
        return output.ToArray();
    }
    public (int, Dictionary<int, int>?) MinCoins(int[] coins, int amount)
    {
        int max = amount + 1;
        int[] dp = new int[amount + 1];
        Dictionary<int, int>[] coinCount = new Dictionary<int, int>[amount + 1];
        for (int i = 0; i < coinCount.Length; i++)
        {
            coinCount[i] = new Dictionary<int, int>();
        }

        Array.Fill(dp, max);
        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            for (int j = 0; j < coins.Length; j++)
            {
                if (coins[j] <= i && dp[i - coins[j]] + 1 < dp[i])
                {
                    dp[i] = dp[i - coins[j]] + 1;
                    coinCount[i] = new Dictionary<int, int>(coinCount[i - coins[j]]);
                    if (coinCount[i].ContainsKey(coins[j]))
                    {
                        coinCount[i][coins[j]]++;
                    }
                    else
                    {
                        coinCount[i][coins[j]] = 1;
                    }
                }
            }
        }

        return dp[amount] > amount ? (-1, null) : (dp[amount], coinCount[amount]);
    }
   
}