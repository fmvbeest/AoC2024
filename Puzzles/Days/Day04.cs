using AoC2024.Days.Base;
using AoC2024.Util;

namespace AoC2024.Days;

public class Day04 : PuzzleBase<Grid2D, int, int>
{
    protected override string Filename => "Input/day04.txt";
    protected override string PuzzleTitle => "--- Day 4: Ceres Search ---";
    
    public override int PartOne(Grid2D grid)
    {
        return grid.GetMappedValues('X').Sum(x => IsMasMas(grid, x));
    }

    public override int PartTwo(Grid2D grid)
    {
        return grid.GetMappedValues('A').Count(x => IsXmas2(grid, x));
    }

    private static int IsMasMas(Grid2D grid, Coordinate c)
    {
        var xmas = 0;
        
        var ms = grid.GetNeighboursWithValue(c, 'M');

        foreach (var m in ms)
        {
            var diff = m - c;
            var posA = m + diff;
            
            if (!grid.OnGrid(posA)) continue;
            
            var posAValue = grid.GetValue(posA);

            if (posAValue != 3) continue;

            var posS = posA + diff;
            if (!grid.OnGrid(posS)) continue;
            
            var posSValue = grid.GetValue(posA + diff);
            
            if (posSValue != 4) continue;

            xmas += 1;
        }
        
        return xmas;
    }
    
    private static bool IsXmas2(Grid2D grid, Coordinate a)
    {
        var ms = grid.GetNeighboursDiagonalWithValue(a, 'M').ToArray();

        if (ms.Length != 2) return false;
        
        foreach (var m in ms)
        {
            var posS = a - (m - a);
            
            if (!grid.OnGrid(posS)) return false;
            
            var posSValue = grid.GetValue(posS);

            if (posSValue != 4) return false;
        }
        
        return true;
    }

    public override Grid2D Preprocess(IPuzzleInput input, int part = 1)
    {
        var map = new Dictionary<char, int> { ['X'] = 1, ['M'] = 2, ['A'] = 3, ['S'] = 4 };
        
        var grid = new Grid2D(input.GetAllLines(), map);

        return grid;
    }
}