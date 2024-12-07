using AoC2024.Days;
using AoC2024.Days.Base;

namespace Tests;

public class TestDay07
{
    private readonly PuzzleInput _testInput = new("Input/day07-test.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/day07.txt");
    private readonly Day07 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(3749, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(975671981569, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }

    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(11387, _puzzle.PartTwo(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(223472064194845, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}