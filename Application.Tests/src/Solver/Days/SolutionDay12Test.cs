using Application.Solver.Days;
using Application.Tests.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay12Test : SolutionDay12
{
    private const string Input = """
                                 RRRRIICCFF
                                 RRRRIICCCF
                                 VVRRRCCFFF
                                 VVRCCCJFFF
                                 VVVVCJJCFE
                                 VVIVCCJJEE
                                 VVIIICJJEE
                                 MIIIIIJJEE
                                 MIIISIJEEE
                                 MMMISSJEEE
                                 """;

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay12>(1, Input, 1930);
    
    
    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay12>(1, 1549354);

    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay12>(2, Input, 1206);

    private const string Input2 = """
                                  AAAA
                                  BBCD
                                  BBCC
                                  EEEC
                                  """;

    [TestMethod]
    public void ResolvePart2Test2() => TestHelpers.TestPart<SolutionDay12>(2, Input2, 80);

    private const string Input3 = """
                                  OOOOO
                                  OXOXO
                                  OOOOO
                                  OXOXO
                                  OOOOO
                                  """;

    [TestMethod]
    public void ResolvePart2Test3() => TestHelpers.TestPart<SolutionDay12>(2, Input3, 436);    

    private const string Input4 = """
                                  AAAAAA
                                  AAABBA
                                  AAABBA
                                  ABBAAA
                                  ABBAAA
                                  AAAAAA
                                  """;

    [TestMethod]
    public void ResolvePart2Test4() => TestHelpers.TestPart<SolutionDay12>(2, Input4, 368);
    
    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay12>(2, 937032);
}