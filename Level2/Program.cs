string part = "5";

var input = File.ReadAllLines($"Data/level3_{part}.in");

var output = new List<string>();

foreach (var line in input.Skip(1))
{
    
    var playerCounts = ExtractPlayers(line);
    var players = GetRandomPlayers(playerCounts.r, playerCounts.p, playerCounts.s);
    var after = MakeMatches(players, 2);
        
}

File.WriteAllLines($"Data/level3_{part}.out", output);
Console.WriteLine(string.Join("\n", output));


static (int r,int p,int s) ExtractPlayers(string players)
{
    int r = players[0];
    int p = players[3];
    int s = players[6];
    return (r,p,s);
}

static string GetRandomPlayers(int rocks, int papers, int scissors)
{
    var players = new List<string>();
    for (int i = 0; i < rocks; i++)
    {
        players.Add("R");
    }
    for (int i = 0; i < papers; i++)
    {
        players.Add("P");
    }
    for (int i = 0; i < scissors; i++)
    {
        players.Add("S");
    }

    return string.Join("", players.Order(new RandomComparer()));
}

static string MakeMatches(string players,int rounds)
{
    for (int i = 0; i < rounds; i++)
    {
        players = Match(players);
    }

    return players;
}


static string Match(string players)
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



static Type GetWinner(Type a, Type b)
{
    if (a.Equals(b)) return a;
    if (a  == Type.R && b == Type.S) return a;
    if(a == Type.S && b == Type.R) return b;
    
    return (int) a > (int) b 
        ? a 
        : b;
}
class RandomComparer : IComparer<string>
{
    
    public int Compare(string x, string y)
    {
        var rnd = new Random();
        return (int)( 0.5 - rnd.NextDouble());
    }
}
enum Type
{
    R = 1,
    P = 2,
    S = 3
}