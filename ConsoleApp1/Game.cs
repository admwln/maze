namespace ConsoleApp1;
class Game
{
    ScheduleTimer? _timer;
    public bool Paused { get; private set; }
    public bool GameOver { get; private set; }
    public void Start(Game game, Maze maze)
    {
        //Console.WriteLine("Start");
        
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
}