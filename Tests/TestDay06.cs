using AoC2024.Days;
using AoC2024.Days.Base;

namespace Tests;

public class TestDay06
{
    private readonly PuzzleInput _testInput = new("Input/day06-test.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/day06.txt");
    private readonly Day06 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(41, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(5461, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }

    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(6, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(1836, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}