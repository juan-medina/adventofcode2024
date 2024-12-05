namespace Application.Solver.Day5;

public class SolutionDay5() : DaySolver(5)
{
    public override int Resolve(int part, string input)
    {
        var (rules, updates) = ParseInput(input);
        var toProcess = updates
            .Where(update => update.Select((_, i) => !update.Select((t2, j) => j > i
                        ? rules.Any(rule => rule.Item1 == update[i] && rule.Item2 == t2)
                        : rules.Any(rule => rule.Item1 == t2 && rule.Item2 == update[i]))
                    .Where((valid, j) => !valid && i != j).Any())
                .All(x => x) == (part == 1))
            .ToList();
        foreach (var update in toProcess)
        {
            update.Sort((page1, page2) =>
            {
                var rule = rules.FirstOrDefault(r =>
                    (r.Item1 == page1 && r.Item2 == page2) || (r.Item1 == page2 && r.Item2 == page1));
                if (!rule.Equals(default))
                {
                    return rule.Item1 == page1 ? 1 : -1;
                }

                return 0;
            });
        }


        return toProcess.Sum(update => update[update.Count / 2]);
    }

    protected static (List<(int, int)>, List<List<int>>) ParseInput(string input)
    {
        var lines = GetListFromString(input);
        var rules = lines
            .Where(line => line.Contains('|'))
            .Select(line => line.Split('|'))
            .Select(tokens => (int.Parse(tokens[0]), int.Parse(tokens[1])))
            .ToList();

        var pages = lines
            .Where(line => line.Contains(','))
            .Select(line => line.Split(',').Select(int.Parse).ToList())
            .ToList();

        return (rules, pages);
    }
}