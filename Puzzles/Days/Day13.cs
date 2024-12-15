using AoC2024.Days.Base;
using MathNet.Numerics.LinearAlgebra;

namespace AoC2024.Days;

public class Day13 : PuzzleBase<Day13.ClawMachine[], long, long>
{
    protected override string Filename => "Input/day13.txt";
    protected override string PuzzleTitle => "--- Day 13: Claw Contraption ---";
    
    public override long PartOne(ClawMachine[] clawMachines)
    {
        return clawMachines.Sum(Solution);
    }

    public override long PartTwo(ClawMachine[] clawMachines)
    {
        return clawMachines.Sum(Solution);
    }

    private static long Solution(ClawMachine c)
    {
        var A = Matrix<double>.Build.DenseOfArray(new double[,] {
            { c.A.x, c.B.x },
            { c.A.y, c.B.y }
        });
        var b = Vector<double>.Build.Dense([c.Prize.x, c.Prize.y]);
        var x = A.Solve(b);

        if (Math.Abs(x[0] - Math.Round(x[0])) < 0.0001 && Math.Abs(x[1] - Math.Round(x[1])) < 0.0001)
        {
            return 3 * Convert.ToInt64(Math.Round(x[0])) + Convert.ToInt64(Math.Round(x[1]));
        }

        return 0;
    }

    public override ClawMachine[] Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetChunkedInput()
            .Select(machineConfig => machineConfig.ToArray())
            .Select(config => new ClawMachine { 
                A = ParseLine(config[0]), 
                B = ParseLine(config[1]), 
                Prize = ParseLine(config[2], part:part) 
            }).ToArray();
    }

    private static (long, long) ParseLine(string line, int part = 1)
    {
        var parts = line.Split(':', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        parts = parts[1].Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var x = long.Parse(parts[0][2..]);
        var y = long.Parse(parts[1][2..]);
        return part == 1 ? (x, y) : (x + 10000000000000, y + 10000000000000);
    }
    
    public class ClawMachine
    {
        public (long x, long y) A { get; init; }
        public (long x, long y) B { get; init; }
        public (long x, long y) Prize { get; init; }
    }
}