using Application.Solver.Days;
using Application.Tests.Test;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay08Test : SolutionDay08
{
    private const string Input = """
                                 ............
                                 ........0...
                                 .....0......
                                 .......0....
                                 ....0.......
                                 ......A.....
                                 ............
                                 ............
                                 ........A...
                                 .........A..
                                 ............
                                 ............
                                 """;

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay08>(1, Input, 14);

    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay08>(1, 220);

    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay08>(2, Input, 34);

    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay08>(2, 813);
}