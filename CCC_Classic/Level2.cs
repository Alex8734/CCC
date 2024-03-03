using CCC_Classic.Utils;
using static CCC_Classic.Level1;

namespace CCC_Classic;

public class Level2:Level
{
    public override string[] Start(string[] lines)
    {
        var output = new List<string>();
        foreach (var line in lines.Skip(1))
        {
            output.Add(MakeMatches(line, 2));
        }
        return output.ToArray();
    }


    public static string MakeMatches(string players,int rounds)
    {
        for (int i = 0; i < rounds; i++)
        {
            players = Match(players);
        }

        return players;
    }


    private static string Match(string players)
    {
        var winners = new List<string>();
        for (int i = 0; i < players.Length; i+=2)
        {
            var a = Enum.Parse<Type>(players[i].ToString());
            var b = Enum.Parse<Type>(players[i+1].ToString());
            winners.Add(GetWinner(a, b).ToString());
        }
    
        return string.Join("", winners);
    }
}