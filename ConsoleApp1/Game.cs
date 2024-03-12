namespace ConsoleApp1;

public class Game
{
    private ScheduleTimer? _timer;
    public bool Paused { get; private set; }
    private bool GameOver { get; set; }
    public void Start(Game game, Maze maze)
    {
        ScheduleNextTick();
        while (!game.GameOver)
        {
            // Listen to keys
            //var ch = Console.ReadKey(false).Key;
            var keyInfo = Console.ReadKey(true);
            
            switch (keyInfo.Key)
            {
                // PlayerOne
                case ConsoleKey.UpArrow:
                    maze.Move("up", maze.PlayerOne);
                    break;
                case ConsoleKey.DownArrow:
                    maze.Move("down", maze.PlayerOne);
                    break;
                case ConsoleKey.RightArrow:
                    maze.Move("right", maze.PlayerOne);
                    break;
                case ConsoleKey.LeftArrow:
                    maze.Move("left", maze.PlayerOne);
                    break;
                // PlayerTwo
                case ConsoleKey.W:
                    maze.Move("W", maze.PlayerTwo);
                    break;
                case ConsoleKey.S:
                    maze.Move("S", maze.PlayerTwo);
                    break;
                case ConsoleKey.A:
                    maze.Move("A", maze.PlayerTwo);
                    break;
                case ConsoleKey.D:
                    maze.Move("D", maze.PlayerTwo);
                    break;
            }
        }
    }

    public void Pause()
    {
        Console.WriteLine("Pause");
        Paused = true;
        _timer!.Pause();
    }

    public void Resume()
    {
        Console.WriteLine("Resume");
        Paused = false;
        _timer!.Resume();
    }

    public void Stop()
    {
        Console.WriteLine("Stop");
        GameOver = true;
    }

    public void Input(ConsoleKey key)
    {
        //Console.WriteLine($"Player pressed key: {key}");
        
        //Move player and redraw maze
        //Maze.Move(key);
    }

    void Tick()
    {
        //Console.WriteLine("Tick");
        ScheduleNextTick();
    }

    void ScheduleNextTick()
    {
        // the game will automatically update itself every half a second, adjust as needed
        _timer = new ScheduleTimer(500, Tick);
    }

    public void DeclareWinner(Player winner)
    {
        GameOver = true;
        
        var longLine = new string(' ', 50);
        Console.BackgroundColor = winner.Color;
        Console.SetCursorPosition(0, 8);
        Console.WriteLine(longLine);Console.SetCursorPosition(0, 13);
        Console.WriteLine(longLine);
        Console.BackgroundColor = ConsoleColor.Black;
        for (var i = 0; i < 4; i++)
        {
            Console.SetCursorPosition(0, 9+i);
            Console.WriteLine(longLine);
        }
        
        Console.ForegroundColor = winner.Color;
        Console.SetCursorPosition(15, 10);
        Console.WriteLine($"The winner is {winner.Name}!!!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(13, 11);
        Console.Write("Press Enter to play again!");
        Console.ReadLine();
        // Clear console and reset cursor
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        GameOver = false;
        Main.RestartGame();
    }
       
}