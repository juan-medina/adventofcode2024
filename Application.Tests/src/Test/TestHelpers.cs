using System.IO;
using Application.Solver;
using FluentAssertions;

namespace Application.Tests.Test;

public abstract class TestHelpers
{
    public static void TestPart<T>(int part, string input, ulong expected) where T : DaySolver, new()
    {
        new T().Resolve(part, input, true).Should().Be(expected);
    }

    public static void TestFullFile<T>(int part, ulong expected) where T : DaySolver, new()
    {
        var solver = new T();
        solver.Resolve(part, GetFullRunFile(solver.Day), false).Should().Be(expected);
    }

    private static string GetFullRunFile(int day, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "")
    {
        var path = Path.GetDirectoryName(filePath);
        for (var i = 0; i < 3; i++)
        {
            path = Path.GetDirectoryName(path);
        }

        var dataPath = Path.Combine(Path.Combine(path!, "application"), "data", $"day_{day:D2}_input.txt");
        return File.ReadAllText(dataPath);
    }
}