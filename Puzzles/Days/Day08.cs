using AoC2024.Days.Base;
using AoC2024.Util;

namespace AoC2024.Days;

public class Day08 : PuzzleBase<Grid2D, int, int>
{
    protected override string Filename => "Input/day08.txt";
    protected override string PuzzleTitle => "--- Day 8: Resonant Collinearity ---";
    
    public override int PartOne(Grid2D grid)
    {
        var antennaTypes = grid.GetDistinctCharValues().Where(c => c != '.').ToArray();

        return FindAntiNodes(grid, antennaTypes, part:1).Count();
    }

    public override int PartTwo(Grid2D grid)
    {
        var antennaTypes = grid.GetDistinctCharValues().Where(c => c != '.').ToArray();

        return FindAntiNodes(grid, antennaTypes, part:2).Count();
    }

    private static IEnumerable<Coordinate> FindAntiNodes(Grid2D grid, char[] antennaTypes, int part = 1)
    {
        var antiNodes = new HashSet<Coordinate>();
        
        foreach (var antennaType in antennaTypes)
        {
            var antennas = grid.GetMappedValues(antennaType).ToArray();

            foreach (var antenna in antennas)
            {
                foreach (var otherAntenna in antennas.Where(c => !c.Equals(antenna)))
                {
                    antiNodes.UnionWith(GetAntiNodes(grid, antenna, otherAntenna, part:part));
                }
            }
        }

        return antiNodes;
    }

    private static IEnumerable<Coordinate> GetAntiNodes(Grid2D grid, Coordinate x, Coordinate y, int part = 1)
    {
        var antiNodes = new List<Coordinate>();
        var diff = x - y;

        if (part == 1)
        {
            antiNodes.AddRange([x + diff, y - diff]);
            return antiNodes.Where(grid.OnGrid);
        }

        antiNodes.AddRange(GetAllAntiNodes(grid, x, diff));
        antiNodes.AddRange(GetAllAntiNodes(grid, y, diff));
        
        return antiNodes;
    }

    private static List<Coordinate> GetAllAntiNodes(Grid2D grid, Coordinate c, Coordinate diff)
    {
        var antiNodes = new List<Coordinate>();
        var antiNode = c + diff;
        
        while (grid.OnGrid(antiNode))
        {
            antiNodes.Add(antiNode);
            antiNode += diff;
        }

        return antiNodes;
    }

    public override Grid2D Preprocess(IPuzzleInput input, int part = 1)
    {
        return new Grid2D(input.GetAllLines());
    }
}