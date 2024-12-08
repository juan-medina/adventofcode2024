using Application.Solver.Days;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay06Test : SolutionDay06
{
    private const string Input = """
                                 ....#.....
                                 .........#
                                 ..........
                                 ..#.......
                                 .......#..
                                 ..........
                                 .#..^.....
                                 ........#.
                                 #.........
                                 ......#...
                                 """;

    private const int Part1Expected = 41;

    [TestMethod]
    public void ResolvePart1Test() => new SolutionDay06().Resolve(1, Input).Should().Be(Part1Expected);

    private const int Part2Expected = 6;

    [TestMethod]
    public void ResolvePart2Test() => new SolutionDay06().Resolve(2, Input).Should().Be(Part2Expected);
}