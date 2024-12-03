namespace AoC2024.Days.Base;

public interface IPuzzleInput
{
    public IEnumerable<string> GetAllLines();

    public string GetFirstLine();

    public string GetText();

    public IEnumerable<IEnumerable<string>> GetChunkedInput();
}