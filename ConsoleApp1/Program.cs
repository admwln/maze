using ConsoleApp1;

var game = new Game();
Console.Write("Player 1, choose your name: ");
var name = Console.ReadLine();
var playerOne = new Player(name);
Console.WriteLine("Press Enter to play!");
Console.ReadLine();
var maze = new Maze(playerOne);
game.Start();
maze.Draw();
Console.SetCursorPosition(0,22);
Console.WriteLine($"{playerOne.Name}: {playerOne.Score}");
while ( ! game.GameOver)
{
    // Listen to keys
    var ch = Console.ReadKey(false).Key;
    switch(ch)
    {
        case ConsoleKey.UpArrow:
            maze.Move("up");
            break;
        case ConsoleKey.DownArrow:
            maze.Move("down");
            break;
        case ConsoleKey.RightArrow:
            maze.Move("right");
            break;
        case ConsoleKey.LeftArrow:
            maze.Move("left");
            break;
    }
    
    // listen to key presses
    // if (Console.KeyAvailable)
    // {
    //     var input = Console.ReadKey(true);
    //
    //     switch (input.Key)
    //     {
    //         // send key presses to the game if it's not paused
    //         case ConsoleKey.UpArrow:
    //         case ConsoleKey.DownArrow:
    //         case ConsoleKey.LeftArrow:
    //         case ConsoleKey.RightArrow:
    //             if (!game.Paused)
    //                 game.Input(input.Key);
    //             break;
    //
    //         case ConsoleKey.P:
    //             if (game.Paused)
    //                 game.Resume();
    //             else
    //                 game.Pause();
    //             break;
    //
    //         case ConsoleKey.Escape:
    //             game.Stop();
    //             return;
    //     }
    // }
}