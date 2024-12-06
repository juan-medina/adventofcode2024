using Application.Solver.Days;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay02Test : SolutionDay02
{
    private const string Part1Input = """
                                      7 6 4 2 1
                                      1 2 7 8 9
                                      9 7 6 2 1
                                      1 3 2 4 5
                                      8 6 4 4 1
                                      1 3 6 7 9
                                      """;

    private const int Part1Expected = 2;
    
    [TestMethod]
    public void ResolvePart1Test() => new SolutionDay02().Resolve(1, Part1Input).Should().Be(Part1Expected);

    private const string Part2Input = """
                                      7 6 4 2 1
                                      1 2 7 8 9
                                      9 7 6 2 1
                                      1 3 2 4 5
                                      8 6 4 4 1
                                      1 3 6 7 9
                                      """;

    private const int Part2Expected = 4;

    [TestMethod]
    public void ResolvePart2Test() => new SolutionDay02().Resolve(2, Part2Input).Should().Be(Part2Expected);
}