using AoC2024.Days.Base;
using AoC2024.Util;

namespace AoC2024.Days;

public class Day04 : PuzzleBase<IEnumerable<string>, int, int>
{
    protected override string Filename => "Input/day04.txt";
    protected override string PuzzleTitle => "--- Day 4: Ceres Search ---";
    
    public override int PartOne(IEnumerable<string> input)
    {
        var map = new Dictionary<char, int> { ['X'] = 1, ['M'] = 2, ['A'] = 3, ['S'] = 4 };
        
        var grid = new Grid2D(input, map);

        var xs = grid.GetMappedValues('X');

        return xs.Sum(x => IsXmas(grid, x));
    }

    public override int PartTwo(IEnumerable<string> input)
    {
        var map = new Dictionary<char, int> { ['X'] = 1, ['M'] = 2, ['A'] = 3, ['S'] = 4 };
        
        var grid = new Grid2D(input, map);

        var xs = grid.GetMappedValues('A');

        return xs.Count(x => IsXmas2(grid, x));
    }

    private int IsXmas(Grid2D grid, Coordinate c)
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
    
    private bool IsXmas2(Grid2D grid, Coordinate c)
    {
        var ms = grid.GetNeighboursWithValue(c, 'M').ToArray();

        if (ms.Length != 2) return false;
        
        foreach (var m in ms)
        {
            var diff = m - c;
            var posS = c - diff;
            
            if (!grid.OnGrid(posS)) return false;
            
            var posSValue = grid.GetValue(posS);

            if (posSValue != 4) return false;
        }
        
        return true;
    }

    public override IEnumerable<string> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines();
    }
}