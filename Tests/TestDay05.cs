using AoC2024.Days;
using AoC2024.Days.Base;

namespace Tests;

public class TestDay05
{
    private readonly PuzzleInput _testInput = new("Input/day05-test.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/day05.txt");
    private readonly Day05 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(143, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(4959, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }

    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(123, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(4655, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}