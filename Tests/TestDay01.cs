using AoC2024.Days;
using AoC2024.Days.Base;

namespace Tests;

public class TestDay01
{
    private readonly PuzzleInput _testInput = new("Input/day01-test.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/day01.txt");
    private readonly Day01 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(11, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(1197984, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }

    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(31, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(23387399, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}