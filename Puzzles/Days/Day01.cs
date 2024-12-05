using AoC2024.Days.Base;

namespace AoC2024.Days;

public class Day01 : PuzzleBase<(int[] a, int[] b), int, int>
{
    protected override string Filename => "Input/day01.txt";
    protected override string PuzzleTitle => "--- Day 1: Historian Hysteria ---";

    public override int PartOne((int[] a, int[] b) input)
    {
        return input.a.Select((t, i) => Math.Abs(t - input.b[i])).Sum();
    }

    public override int PartTwo((int[] a, int[] b) input)
    {
        return input.a.Sum(number => number * input.b.Count(x => x == number));
    }

    public override (int[] a, int[] b) Preprocess(IPuzzleInput input, int part = 1)
    {
        var cleanInput = input.GetAllLines()
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToArray();
        
        var a = cleanInput.Select(x => int.Parse(x[0])).Order().ToArray();
        var b = cleanInput.Select(x => int.Parse(x[1])).Order().ToArray();
        
        return (a, b);
    }
}