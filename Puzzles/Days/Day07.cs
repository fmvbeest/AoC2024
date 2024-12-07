using AoC2024.Days.Base;

namespace AoC2024.Days;

public class Day07 : PuzzleBase<IEnumerable<Day07.Equation>, long, long>
{
    protected override string Filename => "Input/day07.txt";
    protected override string PuzzleTitle => "--- Day 7: Bridge Repair ---";
    
    private static long Add(long x, long y) => x + y;

    private static long Multiply(long x, long y) => x * y;

    private static long Concatenate(long x, long y) => long.Parse(x.ToString() + y);
    
    public override long PartOne(IEnumerable<Equation> input)
    {
        var operators = new[] {Add, Multiply};

        return input.Where(e => Test(e.Operands, operators, e.TestValue))
            .Sum(e => e.TestValue);
    }

    public override long PartTwo(IEnumerable<Equation> input)
    {
        var operators = new[] {Add, Multiply, Concatenate};

        return input.Where(e => Test(e.Operands, operators, e.TestValue))
            .Sum(e => e.TestValue);
    }

    private static bool Test(int[] operands, Func<long, long, long>[] operators, long testValue)
    {
        var intermediateResults = new List<long> { operands[0] };
        
        for (var i = 1; i < operands.Length; ++i)
        {
            var tmp = new List<long>();
            foreach (var result in intermediateResults)
            {
                foreach (var func in operators)
                {
                    var res = func(result, operands[i]);
                    if (res <= testValue)
                        tmp.Add(res);
                }
            }
            intermediateResults = tmp;
        }

        return intermediateResults.Contains(testValue);
    }

    public override IEnumerable<Equation> Preprocess(IPuzzleInput input, int part = 1)
    {
        return (from line in input.GetAllLines() 
            select line.Split(':', StringSplitOptions.TrimEntries) into s 
            let testValue = long.Parse(s[0]) 
            let operands = s[1].Split(' ', StringSplitOptions.TrimEntries).Select(int.Parse).ToArray() 
            select new Equation(testValue, operands)).ToList();
    }

    public class Equation(long testValue, int[] operands)
    {
        public long TestValue { get; set; } = testValue;
        public int[] Operands { get; set; } = operands;
    }
}