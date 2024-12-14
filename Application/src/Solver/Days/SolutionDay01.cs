using Application.Helpers;

namespace Application.Solver.Days;

public class SolutionDay01() : DaySolver(1)
{
    public override ulong Resolve(int part, string input, bool _)
    {
        var (left, right) = SplitInLeftRightLists(input);
        return (ulong)(part == 1 ? Part1(left, right) : Part2(left, right));
    }

    protected static (List<int>, List<int>) SplitInLeftRightLists(string input)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();
        foreach (var items in StringHelpers.GetListFromString(input).Select(line =>
                     line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()))
        {
            list1.Add(items.First());
            list2.Add(items.Last());
        }

        return (list1, list2);
    }

    private static int Part1(List<int> left, List<int> right) => left.OrderBy(number => number)
        .Zip(right.OrderBy(number => number), (minLeft, minRight) => Math.Abs(minLeft - minRight)).Sum();

    private static int Part2(List<int> left, List<int> right) => left.Select((number, _) =>
        number * right.Count(found => found == number)).Sum();
}