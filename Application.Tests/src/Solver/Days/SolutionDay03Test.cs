using Application.Solver.Days;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay03Test : SolutionDay03
{
    private const string Part1Input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

    private const int Part1Expected = 161;
    
    [TestMethod]
    public void ResolvePart1Test() => new SolutionDay03().Resolve(1, Part1Input).Should().Be(Part1Expected);    
    
    private const string Part2Input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

    private const int Part2Expected = 48;
    
    [TestMethod]
    public void ResolvePart2Test() => new SolutionDay03().Resolve(2, Part2Input).Should().Be(Part2Expected);        
    
}