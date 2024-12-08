using Application.Solver.Days;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay04Test : SolutionDay04
{
    private const string Input = """
                                 MMMSXXMASM
                                 MSAMXMSMSA
                                 AMXSXMAAMM
                                 MSAMASMSMX
                                 XMASAMXAMM
                                 XXAMMXXAMA
                                 SMSMSASXSS
                                 SAXAMASAAA
                                 MAMMMXMMMM
                                 MXMXAXMASX
                                 """;

    private const int Part1Expected = 18;

    [TestMethod]
    public void ResolvePart1Test() => new SolutionDay04().Resolve(1, Input).Should().Be(Part1Expected);

    private const int Part2Expected = 9;

    [TestMethod]
    public void ResolvePart2Test() => new SolutionDay04().Resolve(2, Input).Should().Be(Part2Expected);
}