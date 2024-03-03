using System.Diagnostics;
using Level3;

string part = "1";

var input = File.ReadAllLines($"Data/level3_{part}.in");


var validation = new List<bool>();
var output = new List<string>();
foreach (var line in input.Skip(1))
{
    var playerCounts = ExtractPlayers(line);
    var players = "";
    
    // keep scissor 
    players += "S";
    playerCounts.s--;
    
    if(playerCounts.s > 0)
    {
        players += "S";
        playerCounts.s--;
    }
    else
    {
        players += "P";
        playerCounts.p--;
    }
    
    if(playerCounts is {r: > 0, p: > 0})
    {
        players += "RP";
        playerCounts.p--;
        playerCounts.r--;
    }
    else if(playerCounts.p > 1)
    {
        players += "PP";
        playerCounts.p -= 2;
    }
    
    // pretend that rock is alone with scissor at last
    if(playerCounts.r %2 == 1 && playerCounts.s %2 == 1)
    {
        
        players += "RS";
        playerCounts.r--;
        playerCounts.s--;
        
        if(playerCounts.p > 1)
        {
            players += "PP";
            playerCounts.p -= 2;
        }
        
    }
    
    
    // small rocks down

    while (playerCounts.r > 0)
    {
        if(playerCounts.r > 1)
        {
            players += "RR";
            playerCounts.r -= 2;
            
        }
        
        if(playerCounts is {r: > 0,p: > 0})
        {
            players += "PR";
            playerCounts.p--;
            playerCounts.r--;
        }
        else if(playerCounts.p > 1)
        {
            players += "PP";
            playerCounts.p -= 2;
        }
        
    }
    

    Console.WriteLine(playerCounts);
    players += new string('R', playerCounts.r);
    players += new string('S', playerCounts.s);
    players += new string('P', playerCounts.p);
    
    
   
    var after = MakeMatches(players, 2);
    output.Add(players);
    Console.WriteLine($"{!after.Contains('R')} && {after.Contains('S')}");
    validation.Add(!after.Contains('R') && after.Contains('S'));
}

/*
    Bruteforcing stuff
    var playerCounts = ExtractPlayers(line);
    var players = GetRandomPlayers(playerCounts.r, playerCounts.p, playerCounts.s);
    var after = MakeMatches(players, 2);; 
    
    while (after.Contains("R")||!after.Contains("S"))
    {
        players = GetRandomPlayers(playerCounts.r, playerCounts.p, playerCounts.s);
        after = MakeMatches(players, 2);
        
    }
    output.Add(players);
    Console.WriteLine(after);
}*/

File.WriteAllLines($"Data/level3_{part}.out", output);
Console.WriteLine();
Console.WriteLine(validation.All(x => x));
//Console.WriteLine(string.Join("\n", output));


static (int r,int p,int s) ExtractPlayers(string players)
{
    var parts = players.Split(" ").Select(s => s.Substring(0,s.Length-1)).ToArray();
    int r = int.Parse(parts[0]);
    int p = int.Parse(parts[1]);
    int s = int.Parse(parts[2]);
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

    return string.Join("", players.OrderBy(x => Guid.NewGuid()));
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

enum Type
{
    R = 1,
    P = 2,
    S = 3
}