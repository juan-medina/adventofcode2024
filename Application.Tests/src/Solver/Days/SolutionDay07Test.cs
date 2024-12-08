using Application.Solver.Days;
using Application.Tests.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay07Test : SolutionDay07
{
    private const string Input = """
                                 190: 10 19
                                 3267: 81 40 27
                                 83: 17 5
                                 156: 15 6
                                 7290: 6 8 6 15
                                 161011: 16 10 13
                                 192: 17 8 14
                                 21037: 9 7 18 13
                                 292: 11 6 16 20
                                 """;
    
    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay07>(1, Input, 3749);

    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay07>(1, 66343330034722ul);

    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay07>(2, Input, 11387);

    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay07>(2, 637696070419031);
}