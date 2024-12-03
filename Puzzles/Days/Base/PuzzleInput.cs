namespace AoC2024.Days.Base;

public class PuzzleInput : IPuzzleInput
{
    private readonly string[] _allLines;
    private readonly string _filename;

    public PuzzleInput(string input, bool file = true)
    {
        if (file)
        {
            _allLines = File.ReadAllLines(input);
            _filename = input;    
        }
        else
        {
            _allLines = [input];
            _filename = string.Empty;;
        }
    }
    
    
    public IEnumerable<string> GetAllLines()
    {
        return _allLines;
    }

    public string GetText()
    {
        return File.ReadAllText(_filename);
    }

    public IEnumerable<IEnumerable<string>> GetChunkedInput()
    {
        var index = 0;
        return _allLines.
            GroupBy(x => !string.IsNullOrEmpty(x) ? index : index++)
            .Select(group => group.Where(s => !string.IsNullOrEmpty(s)));
    }

    public string GetFirstLine()
    {
        return _allLines[0];
    }
}