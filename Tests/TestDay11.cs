using AoC2024.Days;
using AoC2024.Days.Base;

namespace Tests;

public class TestDay11
{
    private readonly PuzzleInput _testInput = new("Input/day11-test.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/day11.txt");
    private readonly Day11 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(55312, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(193269, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }

    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(65601038650482, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(228449040027793, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}