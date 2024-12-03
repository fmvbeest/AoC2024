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
        var inputLines = input.GetAllLines().ToArray();
        var a = new int[inputLines.Length];
        var b = new int[inputLines.Length];

        for (var i = 0; i < inputLines.Length; i++)
        {
            var parts = inputLines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            a[i] = int.Parse(parts[0]);
            b[i] = int.Parse(parts[1]);
        }

        Array.Sort(a);
        Array.Sort(b);
        return (a, b);
    }
}