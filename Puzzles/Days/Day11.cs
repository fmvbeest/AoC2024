using AoC2024.Days.Base;

namespace AoC2024.Days;

public class Day11: PuzzleBase<IEnumerable<long>, long, long>
{
    protected override string Filename => "Input/day11.txt";
    protected override string PuzzleTitle => "--- Day 11: Plutonian Pebbles ---";
    
    public override long PartOne(IEnumerable<long> input)
    {
        return BlinkNTimes(input.ToDictionary(x => x, x => 1L), 25);
    }

    public override long PartTwo(IEnumerable<long> input)
    {
        return BlinkNTimes(input.ToDictionary(x => x, x => 1L), 75);
    }

    private static long BlinkNTimes(Dictionary<long, long> stoneCount, int n)
    {
        for (var i = 0; i < n; i++)
        {
            var tmp = new Dictionary<long, long>();
            foreach (var (key, count) in stoneCount)
            {
                var replacements = Replacements(key);
                foreach (var replacement in replacements.Where(replacement => !tmp.TryAdd(replacement, count)))
                {
                    tmp[replacement] += count;
                }
            }

            stoneCount = tmp;
        }
        
        return stoneCount.Sum(key => key.Value);
    }
    
    private static List<long> Replacements(long stone)
    {
        if (stone == 0) return [1];

        var x = stone.ToString();
        if (x.Length % 2 == 0)
        {
            return [long.Parse(x[..(x.Length / 2)]), long.Parse(x.Substring(x.Length/2, x.Length / 2))];
        }

        return [stone * 2024];
    }

    public override IEnumerable<long> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetText().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse);
    }
}