using AoC2024.Days;
using AoC2024.Days.Base;

namespace Tests;

public class TestDay19
{
    private readonly PuzzleInput _testInput = new("Input/day19-test.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/day19.txt");
    private readonly Day19 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(6, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(350, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }

    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(0, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(0, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}