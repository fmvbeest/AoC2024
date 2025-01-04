using AoC2024.Days.Base;

namespace AoC2024.Days;

public class Day19 : PuzzleBase<Linen, int, int>
{
    protected override string Filename => "Input/day19.txt";
    protected override string PuzzleTitle => "--- Day 19: Linen Layout ---";

    private readonly Dictionary<string, bool> _cache = new();
    
    public override int PartOne(Linen input)
    {
        return input.Designs.Count(design => CheckDesign(input.Patterns, design));
    }

    public override int PartTwo(Linen input) 
    {
        return 0;
    }

    private bool CheckDesign(string[] patterns, string design)
    {
        if (_cache.TryGetValue(design, out var checkDesign))
        {
            return checkDesign;
        }

        if (design.Length == 0)
        {
            return true;
        }

        if (patterns.Where(design.StartsWith).Any(pattern => CheckDesign(patterns, design[pattern.Length..])))
        {
            _cache.TryAdd(design, true);
            return true;
        }

        _cache.TryAdd(design, false);
        return false;
    }

    public override Linen Preprocess(IPuzzleInput input, int part = 1)
    {
        var parts = input.GetChunkedInput().ToArray();
        
        return new Linen(parts.First().First().Split(',', StringSplitOptions.TrimEntries)
            , parts.Last().ToArray());
    }
}

public class Linen(string[] patterns, string[] designs)
{
    public string[] Patterns { get; set; } = patterns;
    public string[] Designs { get; set; } = designs;
}