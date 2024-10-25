using CCC_Classic.Utils;
using CCC_School_40.Data;

namespace CCC_School_40;

public class AlexLevel3 : Level
{
    public override string[] Start(string[] lines)
    {
        var output = new List<string>();
        foreach (var line in lines.Skip(2))
        {
            var ints = line.Split(" ").Select(i => int.Parse(i));
            output.Add(string.Join(" ", CalculateAccelerations(ints.ElementAt(0), int.Parse(lines[1]))));
            //output.Add(string.Join(" ", CalculateAccelerations2(ints.ElementAt(0), int.Parse(lines[1]))));

        }

        return output.ToArray();
    }

    public static List<int> CalculateAccelerations2(int targetHeight, int timeLimit)
    {
        var accelerations = new List<int>();
        int currentHeight = 0;
        int currentVelocity = 0;
        int ticks = 0;

        // Phase 1: Ascend to at least the target height
        while (currentHeight < targetHeight && ticks < timeLimit)
        {
            int acc;

            // Determine acceleration needed to reach or exceed the target height
            int heightDiff = targetHeight - currentHeight;

            // Set acceleration based on remaining height and velocity
            if (heightDiff > currentVelocity * 2)
            {
                acc = Math.Min(20, heightDiff - currentVelocity); // Accelerate moderately
            }
            else
            {
                acc = 10; // Start slowing down
            }

            // Apply the acceleration and update velocity/height
            currentVelocity += acc;
            currentHeight += currentVelocity;
            accelerations.Add(acc);
            ticks++;
        }

        // Phase 2: Begin descent and prepare for a soft landing
        while (currentHeight > 0 && ticks < timeLimit)
        {
            int acc;
            if (currentVelocity > 0)
            {
                acc = 0; // Maintain descent with no additional acceleration
            }
            else
            {
                acc = Math.Max(-currentVelocity, 10); // Adjust to reduce velocity for a soft landing
            }

            // Update velocity and height
            currentVelocity += acc;
            currentHeight = Math.Max(0, currentHeight + currentVelocity);
            accelerations.Add(acc);
            ticks++;
        }

        // Ensure velocity is -1 or 0 upon landing
        if (currentVelocity < -1)
        {
            accelerations.Add(Math.Min(20, -currentVelocity - 1));
        }

        return accelerations;
    }


    public static List<int> CalculateAccelerations(int targetHeight, int timeLimit)
    {
        var accelerations = new List<int>();
        int currentHeight = 0;
        int currentVelocity = 0;

        while (targetHeight > currentHeight)
        {
            var acc = 0;
            if (10 + targetHeight - currentHeight < currentVelocity + 20)
            {
                acc = targetHeight - currentHeight + 10;
            }
            else
            {
                acc = 20;
            }

            currentVelocity += acc;
            accelerations.Add(acc);
            currentHeight = currentVelocity + currentHeight -10;
            Console.WriteLine(currentHeight);
        }

        Console.WriteLine(-300);
        while (currentVelocity -10 > 0)
        {
            currentVelocity -= 10 ;
            currentHeight = currentHeight + currentVelocity;
            accelerations.Add(0);
            Console.WriteLine("ogaaaa" + currentVelocity);
        }

        Console.WriteLine("hhuhuhuhuh"  +currentVelocity);
        accelerations.Add(Math.Abs(currentVelocity) + 10);
        currentVelocity = 0;

        while (currentHeight > 10)
        {
            accelerations.Add(0);
            accelerations.Add(10);
            currentHeight -= 10;
        }

        if (currentHeight != 1)
        {
            accelerations.Add(-10+currentHeight-1);
            currentVelocity = -10 + currentHeight - 1;
        }
        accelerations.Add(Math.Abs(currentVelocity-10)-1);
        accelerations.Add(9);

        return accelerations;
    }
}