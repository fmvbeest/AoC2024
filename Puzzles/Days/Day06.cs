using AoC2024.Days.Base;
using AoC2024.Util;

namespace AoC2024.Days;

public class Day06 : PuzzleBase<Grid2D, int, int>
{
    protected override string Filename => "Input/day06.txt";
    protected override string PuzzleTitle => "--- Day 6: Guard Gallivant ---";
    
    public override int PartOne(Grid2D grid)
    {
        var directions = new[] {Coordinate.Up, Coordinate.Right, Coordinate.Down, Coordinate.Left};
        
        return Traverse(grid, start: grid.GetSingleMappedValue('^'), directions).Count;
    }

    public override int PartTwo(Grid2D grid)
    {
        var directions = new[] {Coordinate.Up, Coordinate.Right, Coordinate.Down, Coordinate.Left};
        var start = grid.GetSingleMappedValue('^');
        var route = Traverse(grid, start, directions).Where(x => !x.Equals(start));
        
        return route.Count(extraObstacle => TraverseWithLoop(grid, start, directions, extraObstacle));
    }

    private static HashSet<Coordinate> Traverse(Grid2D grid, Coordinate start, Coordinate[] directions)
    {
        var visited = new HashSet<Coordinate> { start };
        var current = start;
        var i = 0;
        
        while (grid.OnGrid(current + directions[i]))
        {
            var next = current + directions[i];
            if (!grid.GetCharValue(next).Equals('#'))
            {
                visited.Add(next);
                current = next;
            } 
            else i = (i + 1) % directions.Length;
        }
        
        return visited;
    }

    private static bool TraverseWithLoop(Grid2D grid, Coordinate start, Coordinate[] directions, Coordinate extraObstacle)
    {
        grid.SetGridValue(extraObstacle, '#');
        
        var visited = new Dictionary<int, HashSet<Coordinate>>();
        for (var d = 0; d < directions.Length; d++)
        {
            visited[d] = [];
        }
        
        var foundLoop = false;
        var current = start;
        var i = 0;
        
        while (grid.OnGrid(current + directions[i]))
        {
            var next = current + directions[i];
            if (!grid.GetCharValue(next).Equals('#'))
            {
                if (!visited[i].Add(next))
                {
                    foundLoop = true;
                    break;
                }
                current = next;
            } 
            else i = (i + 1) % directions.Length;
        }
        
        grid.SetGridValue(extraObstacle, '.');
        return foundLoop;
    }
    
    public override Grid2D Preprocess(IPuzzleInput input, int part = 1)
    {
        return new Grid2D(input.GetAllLines(), 
            new Dictionary<char, int> { ['.'] = 1, ['#'] = 2, ['^'] = 3 });
    }
}