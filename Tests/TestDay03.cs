using AoC2024.Days;
using AoC2024.Days.Base;

namespace Tests;

public class TestDay03
{
    private readonly PuzzleInput _puzzleInput = new("Input/day03.txt");
    private readonly Day03 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(161, _puzzle.PartOne("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"));
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(185797128, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }

    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(48, _puzzle.PartTwo("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"));
    }

    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(89798695, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput)));
    }
}