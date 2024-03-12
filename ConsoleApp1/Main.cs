namespace ConsoleApp1;
public static class Main
{
    public static void RestartGame()
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
}