using AoC2024.Days.Base;

namespace AoC2024.Days;

public class Day07 : PuzzleBase<IEnumerable<Day07.TestInput>, long, long>
{
    protected override string Filename => "Input/day07.txt";
    protected override string PuzzleTitle => "--- Day 7: Bridge Repair ---";
    
    public override long PartOne(IEnumerable<TestInput> input)
    {
        var operators = new[] {Add, Multiply};

        return (from testInput in input 
            let results = Test(testInput.Operands, operators) 
            where results.Contains(testInput.TestValue) 
            select testInput.TestValue).Sum();
    }

    public override long PartTwo(IEnumerable<TestInput> input)
    {
        var operators = new[] {Add, Multiply, Concatenate};

        return (from testInput in input 
            let results = Test(testInput.Operands, operators) 
            where results.Contains(testInput.TestValue) 
            select testInput.TestValue).Sum();
    }

    private static IEnumerable<long> Test(int[] operands, Func<long, long, long>[] operators)
    {
        var intermediateResults = new List<long> { operands[0] };
        
        for (var i = 1; i < operands.Length; ++i)
        {
            var tmp = new List<long>();
            foreach (var result in intermediateResults)
            {
                foreach (var func in operators)
                {
                    tmp.Add(func(result,operands[i]));
                }
            }
            intermediateResults.Clear();
            intermediateResults = tmp;
        }

        return intermediateResults;
    }

    private static long Add(long x, long y)
    {
        return x + y;
    }

    private static long Multiply(long x, long y)
    {
        return x * y;
    }

    private static long Concatenate(long x, long y)
    {
        return long.Parse(x.ToString() + y);
    }
    
    public override IEnumerable<TestInput> Preprocess(IPuzzleInput input, int part = 1)
    {
        return (from line in input.GetAllLines() 
            select line.Split(':', StringSplitOptions.TrimEntries) into s 
            let testValue = long.Parse(s[0]) 
            let operands = s[1].Split(' ', StringSplitOptions.TrimEntries).Select(int.Parse).ToArray() 
            select new TestInput(testValue, operands)).ToList();
    }

    public class TestInput(long testValue, int[] operands)
    {
        public long TestValue { get; set; } = testValue;
        public int[] Operands { get; set; } = operands;
    }
}