using Application.Solver.Days;
using Application.Tests.Test;
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

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay04>(1, Input, 18);

    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay04>(1, 2583);

    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay04>(2, Input, 9);

    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay04>(2, 1978);
}