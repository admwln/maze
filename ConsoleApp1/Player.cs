using System.Drawing;

namespace ConsoleApp1;

public class Player(string name, ConsoleColor color, int gridValue, int scoreCursorPosition)
{
    public string Name { get; } = name;
    public int Score { get; set;  } = 0;
    public int ScoreCursorPosition { get; set;  } = scoreCursorPosition;
    public ConsoleColor Color { get; set; } = color;
    public int GridValue { get; set; } = gridValue;

    public void AddToScore(int value)
    {
        Score += value;
    }

    public Player GetPlayer()
    {
        return this;
    }
}
