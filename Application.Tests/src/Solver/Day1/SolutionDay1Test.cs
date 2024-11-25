using Application.Solver.Day1;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Day1;

[TestClass]
[TestSubject(typeof(SolutionDay1))]
public class SolutionDay1Test
{
    private const string Part1Input = """
                                      1abc2
                                      pqr3stu8vwx
                                      a1b2c3d4e5f
                                      treb7uchet
                                      """;

    private const string Part1Expected = "142";


    [TestMethod]
    public void ResolvePart1Test() => Assert.AreEqual(Part1Expected, new SolutionDay1().Resolve(1, Part1Input));

    private const string Part2Input = """
                                      two1nine
                                      eightwothree
                                      abcone2threexyz
                                      xtwone3four
                                      4nineeightseven2
                                      zoneight234
                                      7pqrstsixteen
                                      """;

    private const string Part2Expected = "281";    
    
    [TestMethod]
    public void ResolvePart2Test() => Assert.AreEqual(Part2Expected, new SolutionDay1().Resolve(2, Part2Input));
}