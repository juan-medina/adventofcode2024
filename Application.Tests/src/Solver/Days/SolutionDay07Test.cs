using Application.Solver.Days;
using FluentAssertions;
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

    private const int Part1Expected = 3749;

    [TestMethod]
    public void ResolvePart1Test() => new SolutionDay07().Resolve(1, Input).Should().Be(Part1Expected);

    private const int Part2Expected = 11387;

    [TestMethod]
    public void ResolvePart2Test() => new SolutionDay07().Resolve(2, Input).Should().Be(Part2Expected);
}