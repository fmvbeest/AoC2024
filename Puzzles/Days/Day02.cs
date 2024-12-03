using AoC2024.Days.Base;

namespace AoC2024.Days;

public class Day02 : PuzzleBase<IEnumerable<int[]>, int, int>
{
    protected override string Filename => "Input/day02.txt";
    protected override string PuzzleTitle => "--- Day 2: Red-Nosed Reports ---";

    public override int PartOne(IEnumerable<int[]> input)
    {
        return input.Count(IsSafe);
    }

    public override int PartTwo(IEnumerable<int[]> input)
    {
        return input.Select(levels => levels.Select((x, i) => levels.Where((y, j) => i != j).ToArray()))
            .Count(x => x.Any(IsSafe));
    }

    private static bool IsSafe(int[] levels)
    {
        var diffs = levels.Zip(levels.Skip(1), (x, y) => x - y).ToArray();

        return diffs.All(x => x is >= 1 and <= 3) || diffs.All(x => x is <= -1 and >= -3);
    }
    
    public override IEnumerable<int[]> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines().Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray());
    }
}