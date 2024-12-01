using Application.Helpers;

namespace Application.Solver.Day1;

public class SolutionDay1() : DaySolver(1)
{
    public static (List<int>, List<int>) SplitInLeftRightList(string input)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();
        foreach (var items in GetListFromString(input).Select(line =>
                     line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()))
        {
            list1.Add(items[0]);
            list2.Add(items[1]);
        }

        return (list1, list2);
    }

    public static (int, List<int>) RemoveSmallest(List<int> input)
    {
        if (input.Count == 0) return (0, []);

        var smallest = input[0];
        var smallestIndex = 0;

        for (var i = 1; i < input.Count; i++)
        {
            if (input[i] >= smallest) continue;
            smallest = input[i];
            smallestIndex = i;
        }

        input.RemoveAt(smallestIndex);

        return (smallest, input);
    }

    public override string Resolve(int part, string input)
    {
        var (left, right) = SplitInLeftRightList(input);

        var total = 0;
        var count = left.Count;


        var minLeft = 0;
        var minRight = 0;

        for (int i = 0; i < count; i++)
        {
            if (part == 1)
            {
                (minLeft, left) = RemoveSmallest(left);
                (minRight, right) = RemoveSmallest(right);

                var distance = int.Abs(minRight - minLeft);
                total += distance;
            }
            else
            {
                var numberLeft = left[i];
                var totalTimesInRight = right.Count(x => x == numberLeft);
                total += numberLeft * totalTimesInRight;
            }
        }


        return total.ToString();
    }
}