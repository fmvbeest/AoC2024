using AoC2024.Days;
using AoC2024.Days.Base;

namespace Tests;

public class TestDay02
{
    private readonly PuzzleInput _testInput = new("Input/day02-test.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/day02.txt");
    private readonly Day02 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(2, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(606, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }

    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(4, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(644, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}