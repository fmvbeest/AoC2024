using AoC2024.Days.Base;
using AoC2024.Util;

namespace AoC2024.Days;

public class Day04 : PuzzleBase<Grid2D, int, int>
{
    protected override string Filename => "Input/day04.txt";
    protected override string PuzzleTitle => "--- Day 4: Ceres Search ---";
    
    public override int PartOne(Grid2D grid)
    {
        return grid.GetMappedValues('X').Sum(x => IsXmas(grid, x));
    }

    public override int PartTwo(Grid2D grid)
    {
        return grid.GetMappedValues('A').Count(x => IsMasMas(grid, x));
    }

    private static int IsXmas(Grid2D grid, Coordinate c)
    {
        return grid.GetNeighboursWithValue(c, 'M')
            .Select(m => grid.GetStringValueInDirection(m, m - c, 2))
            .Count(s => s.Equals("AS"));
    }
    
    private static bool IsMasMas(Grid2D grid, Coordinate a)
    {
        var ms = grid.GetNeighboursDiagonalWithValue(a, 'M').ToArray();

        return ms.Length == 2 && 
               ms.Select(m => grid.GetStringValueInDirection(m, -(m - a), 2))
                   .All(s => s.Equals("AS"));
    }

    public override Grid2D Preprocess(IPuzzleInput input, int part = 1)
    {
        return new Grid2D(input.GetAllLines(), 
            new Dictionary<char, int> { ['X'] = 1, ['M'] = 2, ['A'] = 3, ['S'] = 4 });
    }
}