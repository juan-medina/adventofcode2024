using Application.Solver.Days;
using Application.Tests.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay14Test : SolutionDay14
{
    private const string Input = """
                                 p=0,4 v=3,-3
                                 p=6,3 v=-1,-3
                                 p=10,3 v=-1,2
                                 p=2,0 v=2,-1
                                 p=0,0 v=1,3
                                 p=3,0 v=-2,-2
                                 p=7,6 v=-1,-3
                                 p=3,0 v=-1,-2
                                 p=9,3 v=2,3
                                 p=7,3 v=-1,2
                                 p=2,4 v=2,-3
                                 p=9,5 v=-3,-3
                                 """;

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay14>(1, Input, 12);

    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay14>(1, 229421808);

    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay14>(2, Input, 1);

    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay14>(2, 6577U);
}