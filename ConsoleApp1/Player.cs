namespace ConsoleApp1;

public class Player(int id, string name, ConsoleColor color, int gridValue, int scoreCursorPosition)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
    public int Score { get; private set;  }
    public int ScoreCursorPosition { get; } = scoreCursorPosition;
    public ConsoleColor Color { get; } = color;
    public int GridValue { get; } = gridValue;

    public void AddToScore(int value)
    {
        Score += value;
        Console.SetCursorPosition(ScoreCursorPosition,22);
        Console.ForegroundColor = Color;
        Console.WriteLine($"{Name}: {Score}");
    }
}
