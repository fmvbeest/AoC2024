﻿namespace AoC2024.Util;

public class Coordinate : IEquatable<Coordinate>
{
    private readonly (int x, int y) _pos;

    public Coordinate(int x, int y)
    {
        _pos = (x, y);
    }

    public Coordinate(Coordinate pos)
    {
        _pos = (pos.X, pos.Y);
    }

    public int X => _pos.x;

    public int Y => _pos.y;

    public bool Equals(Coordinate? other)
    {
        return other != null && X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj) => Equals(obj as Coordinate);

    public override int GetHashCode() => _pos.GetHashCode();

    public override string ToString() => $"({X},{Y})";

    public static Coordinate operator +(Coordinate a) => a;
    public static Coordinate operator -(Coordinate a) => new(-a.X, -a.Y);
    public static Coordinate operator +(Coordinate a, Coordinate b) => new(a.X + b.X, a.Y + b.Y);
    public static Coordinate operator -(Coordinate a, Coordinate b) => a + (-b);



    public bool IsAdjacentTo(Coordinate x)
    {
        return Neighbours().Contains(x);
    }

    public IEnumerable<Coordinate> Neighbours(bool diagonal = true)
    {
        var neighbours = new List<Coordinate> { (X - 1, Y), (X + 1, Y), (X, Y - 1), (X, Y + 1) };

        if (diagonal)
        {
            neighbours.AddRange(new List<Coordinate> { (X - 1, Y - 1), (X - 1, Y + 1), (X + 1, Y + 1), (X + 1, Y - 1) });
        }

        return neighbours;
    }
    
    public IEnumerable<Coordinate> NeighboursDiagonal()
    {
        return new List<Coordinate> { (X - 1, Y - 1), (X - 1, Y + 1), (X + 1, Y + 1), (X + 1, Y - 1) };;
    }

    public static implicit operator Coordinate((int x, int y) tuple)
    {
        return new Coordinate(tuple.x, tuple.y);
    }

    public void Deconstruct(out int x, out int y)
    {
        x = X;
        y = Y;
    }

    public IEnumerable<Coordinate> Range(Coordinate end)
    {
        var list = new List<Coordinate> { this };

        var diff = end - this;

        var n = 0;
        var e = 0;

        if (diff.X != 0)
        {
            n = Math.Abs(diff.X);
            e = diff.X / n;

            return HorizontalRange(this, e, n, list);
        }

        n = Math.Abs(diff.Y);
        e = diff.Y / n;

        return VerticalRange(this, e, n, list);
    }

    public IEnumerable<Coordinate> HorizontalRange(Coordinate start, int diff, int n, List<Coordinate> list)
    {
        for (int i = 1; i <= n; i++)
        {
            list.Add(new Coordinate(start.X + (diff * i), start.Y));
        }

        return list;
    }

    public IEnumerable<Coordinate> VerticalRange(Coordinate start, int diff, int n, List<Coordinate> list)
    {
        for (int i = 1; i <= n; i++)
        {
            list.Add(new Coordinate(start.X, start.Y + (diff * i)));
        }

        return list;
    }

    public long ManhattanDistance(Coordinate x)
    {
        var diff = this - x;
        return Math.Abs(diff.X) + Math.Abs(diff.Y);
    }

    public static Coordinate FromString(string s)
    {
        var parts = s.Replace("(", "")
            .Replace(")", "").Split(',');

        return new Coordinate(int.Parse(parts[0]), int.Parse(parts[1]));
    }
}