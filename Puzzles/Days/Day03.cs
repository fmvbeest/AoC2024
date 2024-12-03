using System.Text.RegularExpressions;
using AoC2024.Days.Base;

namespace AoC2024.Days;

public partial class Day03 : PuzzleBase<string, int, int>
{
    protected override string Filename => "Input/day03.txt";
    protected override string PuzzleTitle => "--- Day 3: Mull It Over ---";
    
    [GeneratedRegex(@"mul\([0-9]{1,3},[0-9]{1,3}\)", RegexOptions.Compiled)]
    private static partial Regex MulRegex();
    
    [GeneratedRegex(@"(mul\([0-9]{1,3},[0-9]{1,3}\))|(do\(\))|(don\'t\(\))", RegexOptions.Compiled)]
    private static partial Regex MulDoDontRegex();
    
    [GeneratedRegex(@"\d+", RegexOptions.Compiled)]
    private static partial Regex MulFormatRegex();

    public override int PartOne(string input)
    {
        var sum = 0;
        foreach (Match match in MulRegex().Matches(input))
        {
            sum += GetResultFromMatch(match);
        }
        return sum;
    }

    public override int PartTwo(string input)
    {
        var sum = 0;
        var enabled = true;
        
        foreach (Match match in MulDoDontRegex().Matches(input))
        {
            switch (MulFormatRegex().Replace(match.Value, string.Empty))
            {
                case "do()": enabled = true; break;
                case "don't()": enabled = false; break;
                case "mul(,)" when enabled: sum += GetResultFromMatch(match); break; 
            }
        }
        
        return sum;
    }

    private static int GetResultFromMatch(Match match)
    {
        return match.Value.Replace("mul(", "").Replace(")", "").Split(',')
            .Select(int.Parse).Aggregate(1, (x,y) => x * y);
    }
    
    public override string Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetText();
    }
}