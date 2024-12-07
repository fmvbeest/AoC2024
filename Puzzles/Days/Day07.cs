using AoC2024.Days.Base;

namespace AoC2024.Days;

public class Day07 : PuzzleBase<IEnumerable<Day07.TestInput>, long, long>
{
    protected override string Filename => "Input/day07.txt";
    protected override string PuzzleTitle => "--- Day 7: Bridge Repair ---";
    
    private static long Add(long x, long y) => x + y;

    private static long Multiply(long x, long y) => x * y;

    private static long Concatenate(long x, long y) => long.Parse(x.ToString() + y);
    
    public override long PartOne(IEnumerable<TestInput> input)
    {
        var operators = new[] {Add, Multiply};

        return (from testInput in input 
            let results = Test(testInput.Operands, operators, testInput.TestValue) 
            where results.Contains(testInput.TestValue) 
            select testInput.TestValue).Sum();
    }

    public override long PartTwo(IEnumerable<TestInput> input)
    {
        var operators = new[] {Add, Multiply, Concatenate};

        return (from testInput in input 
            let results = Test(testInput.Operands, operators, testInput.TestValue) 
            where results.Contains(testInput.TestValue) 
            select testInput.TestValue).Sum();
    }

    private static IEnumerable<long> Test(int[] operands, Func<long, long, long>[] operators, long testValue)
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

        return intermediateResults;
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