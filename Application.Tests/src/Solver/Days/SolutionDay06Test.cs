using Application.Solver.Days;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay06Test : SolutionDay06
{
    private const string Part1Input = """
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
    public void ResolvePart1Test() => new SolutionDay06().Resolve(1, Part1Input).Should().Be(Part1Expected);
}