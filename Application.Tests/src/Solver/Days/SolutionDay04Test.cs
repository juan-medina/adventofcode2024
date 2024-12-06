using Application.Solver.Days;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay04Test : SolutionDay04
{
    private const string Part1Input = """
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
    public void ResolvePart1Test() => new SolutionDay04().Resolve(1, Part1Input).Should().Be(Part1Expected);

    private const string Part2Input = """
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

    private const int Part2Expected = 9;

    [TestMethod]
    public void ResolvePart2Test() => new SolutionDay04().Resolve(2, Part2Input).Should().Be(Part2Expected);
}