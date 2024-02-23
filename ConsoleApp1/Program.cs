using ConsoleApp1;

var game = new Game();

Console.Write("Player 1, choose your name: ");
var nameOne = Console.ReadLine();
var playerOne = new Player(nameOne, ConsoleColor.Cyan, 2, 25);
Console.Write("Player 2, choose your name: ");
var nameTwo = Console.ReadLine();
var playerTwo = new Player(nameTwo, ConsoleColor.Magenta, 3, 0);

Console.WriteLine("Press Enter to play!");
Console.ReadLine();
var maze = new Maze(playerOne, playerTwo);

maze.Draw();

Console.SetCursorPosition (playerOne.ScoreCursorPosition,22);
Console.ForegroundColor = playerOne.Color;
Console.Write($"{playerOne.Name}: {playerOne.Score}");
Console.SetCursorPosition(playerTwo.ScoreCursorPosition,22);
Console.ForegroundColor = playerTwo.Color;
Console.WriteLine($"{playerTwo.Name}: {playerTwo.Score}");
Console.ForegroundColor = ConsoleColor.Gray;

game.Start(game, maze);