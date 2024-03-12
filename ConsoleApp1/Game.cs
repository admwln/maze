namespace ConsoleApp1;

public class Game
{
    //private ScheduleTimer? _timer;
    //public bool Paused { get; private set; }
    private bool GameOver { get; set; }
    
    public static void Restart()
    {
        var game = new Game();
        var originalBgColor = Console.BackgroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("-----The Amazing Maze Race-----");
        Console.BackgroundColor = originalBgColor;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.Write("Collect 10 yellow coins: ");
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" ");
        Console.BackgroundColor = originalBgColor;
        Console.Write("Your very own portal will appear: ");
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.Write(" ");
        Console.BackgroundColor = originalBgColor;
        Console.Write(" or ");
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" ");
        Console.BackgroundColor = originalBgColor;
        Console.WriteLine("");
        Console.WriteLine("Use your portal to escape and win the game!");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Player 1 ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("(arrow keys), choose your name: ");
        var nameOne = Console.ReadLine();
        var playerOne = new Player(1, nameOne, ConsoleColor.Cyan, 2, 25);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Player 2 ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("(WASD), choose your name: ");
        var nameTwo = Console.ReadLine();
        var playerTwo = new Player(2, nameTwo, ConsoleColor.Magenta, 3, 0);
       
        Console.WriteLine("Press Enter to play!");
        Console.ReadLine();
        var maze = new Maze(playerOne, playerTwo, game, new Grid());
       
        maze.Draw();
       
        Console.SetCursorPosition (playerOne.ScoreCursorPosition,22);
        Console.ForegroundColor = playerOne.Color;
        Console.Write($"{playerOne.Name}: {playerOne.Score}");
        Console.SetCursorPosition(playerTwo.ScoreCursorPosition,22);
        Console.ForegroundColor = playerTwo.Color;
        Console.WriteLine($"{playerTwo.Name}: {playerTwo.Score}");
        Console.ForegroundColor = ConsoleColor.Gray;
       
        game.Start(game, maze); 
    }

    private void Start(Game game, Maze maze)
    {
        //ScheduleNextTick();
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
        Restart();
    }
    // public void Pause()
    // {
    //     Console.WriteLine("Pause");
    //     Paused = true;
    //     _timer!.Pause();
    // }
    //
    // public void Resume()
    // {
    //     Console.WriteLine("Resume");
    //     Paused = false;
    //     _timer!.Resume();
    // }
    //
    // public void Stop()
    // {
    //     Console.WriteLine("Stop");
    //     GameOver = true;
    // }

    // public void Input(ConsoleKey key)
    // {
    //     //Console.WriteLine($"Player pressed key: {key}");
    //     
    //     //Move player and redraw maze
    //     //Maze.Move(key);
    // }

    // void Tick()
    // {
    //     //Console.WriteLine("Tick");
    //     ScheduleNextTick();
    // }

    // void ScheduleNextTick()
    // {
    //     // the game will automatically update itself every half a second, adjust as needed
    //     //_timer = new ScheduleTimer(500, Tick);
    // }
}