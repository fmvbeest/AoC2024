namespace AoC2024.Util;

public class Grid2D
{
    public int X => _grid.GetLength(0);

    public int Y => _grid.GetLength(1);

    private readonly int[,] _grid;

    private readonly Dictionary<char, int> _charToIntMap;

    public Grid2D(IEnumerable<string> input, Dictionary<char, int> charToIntMap)
    {
        var array = input.ToArray();
        _grid = new int[array.Length, array[0].Length];
        _charToIntMap = charToIntMap;
        
        Init(array);
    }

    public Grid2D(IEnumerable<string> input, char[] chars)
    {
        var array = input.ToArray();
        _grid = new int[array.Length, array[0].Length];
        _charToIntMap = new Dictionary<char, int>();
        for (var i = 0; i < chars.Length; i++)
        {
            _charToIntMap.Add(chars[i], i);
        }
        
        Init(array);
    }

    public Grid2D(IEnumerable<string> input)
    {
        _charToIntMap = new Dictionary<char, int>();
        var array = input.ToArray();
        var n = array.Length;
        var m = array[0].Length;
        _grid = new int[n, m];
        
        var row = 0;
        foreach (var s in array)
        {
            var index = 0;
            foreach (var c in s)
            {
                _grid[row, index] = c - '0';
                index++;
            }

            row++;
        }
    }

    private void Init(string[] input)
    {
        var array = input.ToArray();

        var row = 0;
        foreach (var s in array)
        {
            var index = 0;
            foreach (var c in s)
            {
                _grid[row, index] = _charToIntMap[c];
                index++;
            }

            row++;
        }
    }

    public int GetValue(int x, int y)
    {
        return _grid[x, y];
    }

    public int GetValue(Coordinate c)
    {
        return GetValue(c.X, c.Y);
    }

    public IEnumerable<Coordinate> GetMappedValues(char c, bool singleValue = false)
    {
        var coordinates = new List<Coordinate>();
        
        for (var i = 0; i < X; i++)
        {
            for (var j = 0; j < Y; j++)
            {
                if (_grid[i, j] == _charToIntMap[c])
                {
                    if (singleValue) return new [] { new Coordinate(i, j) };
                    
                    coordinates.Add((i,j));
                }
            }
        }

        return coordinates;
    }

    public Coordinate GetSingleMappedValue(char c)
    {
        return GetMappedValues(c, singleValue: true).First();
    }

    public bool OnGrid(Coordinate coordinate)
    {
        return coordinate.X >= 0 && coordinate.X < X && coordinate.Y >= 0 && coordinate.Y < Y;
    }

    public IEnumerable<Coordinate> GetNeighboursWithValue(Coordinate coordinate, char c, bool diagonal = true)
    {
        return coordinate.Neighbours(diagonal).Where(OnGrid)
            .Where(coordinate1 => GetValue(coordinate1) == _charToIntMap[c]);
    }
    
    public IEnumerable<Coordinate> GetNeighboursDiagonalWithValue(Coordinate coordinate, char c, bool diagonal = true)
    {
        return coordinate.NeighboursDiagonal().Where(OnGrid)
            .Where(coordinate1 => GetValue(coordinate1) == _charToIntMap[c]);
    }

    public void SetGridValue(Coordinate coordinate, char c)
    {
        _grid[coordinate.X, coordinate.Y] = _charToIntMap[c];
    }
}