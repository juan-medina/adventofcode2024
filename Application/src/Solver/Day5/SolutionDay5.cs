namespace Application.Solver.Day5;

public class SolutionDay5() : DaySolver(5)
{
    public override int Resolve(int part, string input)
    {
        var (rules, updates) = ParseInput(input);
        var toProcess = new List<List<int>>();

        foreach (var update in updates)
        {
            var updateIsValid = true;
            for (var i = 0; i < update.Count; i++)
            {
                var page = update[i];
                // check pages left from i
                var validFromLeft = true;
                for (var j = i - 1; j > 0; j--)
                {
                    var otherPage = update[j];
                    var valid = rules.Any(rule => rule.Item1 == page && rule.Item2 == otherPage);

                    if (valid) continue;
                    validFromLeft = false;
                    break;
                }

                if (!validFromLeft) continue;
                {
                    // check pages right from i
                    var validFromRight = true;
                    for (var j = i + 1; j < update.Count; j++)
                    {
                        var otherPage = update[j];
                        var valid = rules.Any(rule => rule.Item1 == page && rule.Item2 == otherPage);

                        if (valid) continue;
                        validFromRight = false;
                        break;
                    }

                    if (validFromRight) continue;
                    updateIsValid = false;
                    break;
                }
            }
            
            if (updateIsValid)
            {
                toProcess.Add(update);
            }
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