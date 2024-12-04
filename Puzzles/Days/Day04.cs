using AoC2024.Days.Base;

namespace AoC2024.Days;

public class Day04 : PuzzleBase<IEnumerable<string>, int, int>
{
    protected override string Filename => "Input/day04.txt";
    protected override string PuzzleTitle => "--- Day 4: Ceres Search ---";
    
    public override int PartOne(IEnumerable<string> input)
    {
        return input.Count();
    }

    public override int PartTwo(IEnumerable<string> input)
    {
        return input.Count();
    }

    public override IEnumerable<string> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines();
    }
}