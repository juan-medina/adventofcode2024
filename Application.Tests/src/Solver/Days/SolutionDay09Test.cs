using Application.Solver.Days;
using Application.Tests.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay09Test : SolutionDay09
{
    private const string Input = "2333133121414131402";

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay09>(1, Input, 1928);
    
    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay09>(1, 6341711060162);
    
    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay09>(2, Input, 2858);    
    
    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay09>(2, 6377400869326);
}