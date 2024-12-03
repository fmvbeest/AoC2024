using System.Reflection;
using AoC2024.Days.Base;

namespace AoC2024;

public static class Program
{
    public static void Main(string[] args)
    {
        const string puzzleNameFormat = "Day";
        var puzzleNameBaseLength = puzzleNameFormat.Length;
        
        var puzzles = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IPuzzle))
                        && !t.Name.StartsWith(nameof(PuzzleBase<object, object, object>)))
            .OrderBy(p => int.Parse(p.Name[puzzleNameBaseLength..])).ToList();

        var implementedPuzzles = puzzles.Select(p => int.Parse(p.Name[puzzleNameBaseLength..])).ToArray();

        Console.WriteLine("*** AoC2024 ***");
        Console.WriteLine($"Choose a puzzle to run [{string.Join(", ", implementedPuzzles)}]");
        string? choice = null;

        while (string.IsNullOrEmpty(choice))
        {
            Console.Write("Enter puzzle: ");
            choice = Console.ReadLine();
        }

        if (int.TryParse(choice, out var selection))
        {
            if (implementedPuzzles.Contains(selection))
            {
                var selectedPuzzle = puzzles.First(p => int.Parse(p.Name[puzzleNameBaseLength..]).Equals(selection));
                var instance = Activator.CreateInstance(selectedPuzzle) as IPuzzle;
                instance?.Run();
                Environment.Exit(0);
            }
        }

        foreach (var instance in puzzles.Select(puzzle => Activator.CreateInstance(puzzle) as IPuzzle))
        {
            instance?.Run();
        }
    }
}