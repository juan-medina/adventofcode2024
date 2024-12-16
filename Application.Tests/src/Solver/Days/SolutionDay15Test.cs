using System.Collections.Generic;
using Application.Solver.Days;
using Application.Tests.Test;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Tests.Solver.Days;

[TestClass]
public class SolutionDay15Test : SolutionDay15
{
    private const string Input = """
                                 ##########
                                 #..O..O.O#
                                 #......O.#
                                 #.OO..O.O#
                                 #..O@..O.#
                                 #O#..O...#
                                 #O..O..O.#
                                 #.OO.O.OO#
                                 #....O...#
                                 ##########

                                 <vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^
                                 vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v
                                 ><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<
                                 <<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^
                                 ^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><
                                 ^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^
                                 >^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^
                                 <><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>
                                 ^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>
                                 v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^
                                 """;

    [TestMethod]
    public void ResolvePart1Test() => TestHelpers.TestPart<SolutionDay15>(1, Input, 10092);

    private const string InputSmall = """
                                      ########
                                      #..O.O.#
                                      ##@.O..#
                                      #...O..#
                                      #.#.O..#
                                      #...O..#
                                      #......#
                                      ########

                                      <^^>>>vv<v>>v<<
                                      """;

    [TestMethod]
    public void ResolvePart1TestSmall() => TestHelpers.TestPart<SolutionDay15>(1, InputSmall, 2028);


    [TestMethod]
    public void ResolvePart1TestWithFile() => TestHelpers.TestFullFile<SolutionDay15>(1, 1486930);

    [TestMethod]
    public void ResolvePart2Test() => TestHelpers.TestPart<SolutionDay15>(2, Input, 9021);

    private const string InputVerySmall = """
                                          #######
                                          #...#.#
                                          #.....#
                                          #..OO@#
                                          #..O..#
                                          #.....#
                                          #######

                                          <vv<<^^<<^^
                                          """;

    [TestMethod]
    public void ResolvePart2TestVerySmall() => TestHelpers.TestPart<SolutionDay15>(2, InputVerySmall, 618);

    [TestMethod]
    public void ParsePart1Test()
    {
        const string testParseInput = """
                                      ######
                                      # @  #
                                      # O  #
                                      #  O #
                                      ######

                                      <<
                                      ^
                                      >>>>
                                      """;
        var (obstacles, walls, moves, bot) = Parse(testParseInput, 1);

        List<char> expectedMove =
        [
            '<', '<',
            '^',
            '>', '>', '>', '>'
        ];
        moves.Should().BeEquivalentTo(expectedMove);

        (int y, int x) expectedBot = (1, 2);
        bot.Should().BeEquivalentTo(expectedBot);

        List<(int y, int x, int len)> expectedObstacles =
        [
            (2, 2, 1),
            (3, 3, 1)
        ];
        obstacles.Should().BeEquivalentTo(expectedObstacles);

        walls.Count.Should().Be(18);
    }
}