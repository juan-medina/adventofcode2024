﻿using System.Collections.Generic;
using Application.Solver.Days;
using Application.Tests.Test;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay05Test : SolutionDay05
{
    private const string TestInput = """
                                     1|23
                                     10|4

                                     10,20,30
                                     60,50
                                     """;

    private readonly List<(int, int)> _expectedRules = [(1, 23), (10, 4)];
    private readonly List<List<int>> _expectedUpdates = [new() { 10, 20, 30 }, new() { 60, 50 }];

    [TestMethod]
    public void ParseInputTest()
    {
        var (rules, updates) = ParseInput(TestInput);

        rules.Should().BeEquivalentTo(_expectedRules);
        updates.Should().BeEquivalentTo(_expectedUpdates);
    }

    private const string Input = """
                                 47|53
                                 97|13
                                 97|61
                                 97|47
                                 75|29
                                 61|13
                                 75|53
                                 29|13
                                 97|29
                                 53|29
                                 61|53
                                 97|53
                                 61|29
                                 47|13
                                 75|47
                                 97|75
                                 47|61
                                 75|61
                                 47|29
                                 75|13
                                 53|13

                                 75,47,61,53,29
                                 97,61,53,29,13
                                 75,29,13
                                 75,97,47,61,53
                                 61,13,29
                                 97,13,75,29,47
                                 """;

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay05>(1, Input, 143);

    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay05>(1, 5762);

    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay05>(2, Input, 123);

    [TestMethod]
    public void ResolvePart2TestWithFile() => TestHelpers.TestFullFile<SolutionDay05>(2, 4130);
}