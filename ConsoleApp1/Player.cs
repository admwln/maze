namespace ConsoleApp1;

public class Player(string name)
{
    public string Name { get; } = name;
    public int Score { get; set;  } = 0;

    public void AddToScore(int value)
    {
        Score += value;
    }

    public Player GetPlayer()
    {
        return this;
    }
}
