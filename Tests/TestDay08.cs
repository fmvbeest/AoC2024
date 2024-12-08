using AoC2024.Days;
using AoC2024.Days.Base;

namespace Tests;

public class TestDay08
{
    private readonly PuzzleInput _testInput = new("Input/day08-test.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/day08.txt");
    private readonly Day08 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(14, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(413, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }

    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(34, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(1417, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}