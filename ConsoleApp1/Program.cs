using ConsoleApp1;

var game = new Game();
game.Start();

while ( ! game.GameOver)
{
    // Listen to keys
    var ch = Console.ReadKey(false).Key;
    switch(ch)
    {
        case ConsoleKey.UpArrow:
            Maze.Move("up");
            break;
        case ConsoleKey.DownArrow:
            Maze.Move("down");
            break;
        case ConsoleKey.RightArrow:
            Maze.Move("right");
            break;
        case ConsoleKey.LeftArrow:
            Maze.Move("left");
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