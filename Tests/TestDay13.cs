using AoC2024.Days;
using AoC2024.Days.Base;
using MathNet.Numerics.LinearAlgebra;

namespace Tests;

public class TestDay13
{
    private readonly PuzzleInput _testInput = new("Input/day13-test.txt");
    private readonly PuzzleInput _puzzleInput = new("Input/day13.txt");
    private readonly Day13 _puzzle = new();

    [Fact]
    public void TestPartOneSample()
    {
        Assert.Equal(480, _puzzle.PartOne(_puzzle.Preprocess(_testInput)));
    }

    [Fact]
    public void TestPartOneActual()
    {
        Assert.Equal(26810, _puzzle.PartOne(_puzzle.Preprocess(_puzzleInput)));
    }

    [Fact]
    public void TestPartTwoSample()
    {
        Assert.Equal(875318608908, _puzzle.PartTwo(_puzzle.Preprocess(_testInput, part:2)));
    }

    [Fact]
    public void TestPartTwoActual()
    {
        Assert.Equal(108713182988244, _puzzle.PartTwo(_puzzle.Preprocess(_puzzleInput, part:2)));
    }
}