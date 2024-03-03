using CCC_Classic.Utils;

namespace CCC_Classic;

public class Level1 : Level
{
    public override string[] Start(string[] lines)
    {
        var input = lines.Skip(1);
        var output = new List<string>();
        foreach (var line in input)
        {
            var a = Enum.Parse<Type>(line[0].ToString());
            var b = Enum.Parse<Type>(line[1].ToString());
            output.Add(GetWinner(a, b).ToString());
        }
        
        return output.ToArray();
    }

    internal static Type GetWinner(Type a, Type b)
    {
        if (a.Equals(b)) return a;
        if (a  == Type.R && b == Type.S) return a;
        if(a == Type.S && b == Type.R) return b;
    
        return (int) a > (int) b 
            ? a 
            : b;
    }
    
}
public enum Type
{
    R = 1,
    P = 2,
    S = 3
}