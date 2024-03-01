using System.Runtime.CompilerServices;

namespace ConsoleApp1;
public class Maze(Player playerOne, Player playerTwo, Game game)
{
    public Player PlayerOne { get; } = playerOne;
    public Player PlayerTwo { get; } = playerTwo;

    private Game Game { get; } = game;

    private static int [,] Grid { get; set; } = {
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,2,0},
    {0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0},
    {0,4,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0},
    {0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,0,1,1,1,1,1,1,4,1,0},
    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0},
    {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,4,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,0,1,1,4,1,0,1,1,1,0},
    {0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,4,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,1,0,0,0},
    {0,1,1,1,1,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,4,1,1,1,1,1,0,1,0,1,0,1,1,0,0,0},
    {0,4,0,0,1,0,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0},
    {0,1,1,0,1,0,1,0,0,0,1,0,0,0,0,0,0,0,1,0,1,4,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,4,1,1,1,0,1,0,1,0,0,0,0},
    {0,0,0,0,1,0,1,0,0,0,1,1,1,1,0,0,0,0,1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0},
    {0,1,4,1,1,0,1,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,0,1,0,1,4,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,0,1,0,0,0,0},
    {0,0,0,0,0,0,1,0,1,1,4,1,1,1,0,0,0,0,1,0,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0},
    {0,1,1,4,1,1,1,0,4,0,0,0,0,0,0,0,0,0,1,0,0,1,0,1,0,0,1,1,1,1,1,1,0,1,0,0,0,0,0,1,0,0,0,0,1,1,0,0,0,0},
    {0,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,1,0,0,0,0,1,0,1,1,1,1,1,0,1,0,0,0,0,1,0,0,0,0,0},
    {0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,0,0},
    {0,4,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,4,1,1,1,0,1,0,1,1,1,1,1,1,1,1,4,1,0},
    {0,1,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,4,1,1,1,1,1,1,1,1,1,1,1,1,4,1,0},
    {0,3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
};
    private static readonly int RowCount = Grid.GetLength(0);
    private static readonly int ColCount = Grid.GetLength(1);
     public void Draw()
     {
         // Loop for each row
         for (var row = 0; row < RowCount; row++)
         {
             // Loop for each column
             for (var col = 0; col < ColCount; col++)
             {
                 var originalColor = Console.BackgroundColor;
                 
                 Console.SetCursorPosition(col, row);
         
         
                 if (Grid[row, col] ==  0) // 0 = walls
                 {
                     Console.BackgroundColor = ConsoleColor.Gray;
                    
                 }
                 else if (Grid[row, col] ==  1) // 1 = path
                 {
                     Console.BackgroundColor = ConsoleColor.Black;
                     
                 }
                 else if (Grid[row, col] ==  2) // 2 = PlayerOne
                 {
                     Console.BackgroundColor = PlayerOne.Color;
                    
                 }
                 else if (Grid[row, col] ==  3) // 3 = PlayerTwo
                 {
                     Console.BackgroundColor = PlayerTwo.Color;
                     
                 }
                 else if (Grid[row, col] ==  4) // 4 = coin
                 {
                     Console.BackgroundColor = ConsoleColor.Yellow;
                     
                 }
                 else if (Grid[row, col] ==  5) // 5 = portal for playerOne
                 {
                     Console.BackgroundColor = playerOne.Color;
                 }
                 else if (Grid[row, col] ==  6) // 6 = portal for playerTwo
                 {
                     Console.BackgroundColor = PlayerTwo.Color;
                 }
                 
                 Console.Write(' '); // Write a space to actually change the background color
                 Console.BackgroundColor = originalColor;
             }
         }
     }

     private static void Redraw((int, int) path, Player player, (int, int) playerCoordinates)
     { 
         // Console.WriteLine($"Trying to redraw path at left:{path.Item2} and top {path.Item1}");
         var originalColor = Console.BackgroundColor;
         
         // Draw path
         Console.BackgroundColor = ConsoleColor.Black;
         Console.SetCursorPosition(path.Item2, path.Item1);
         Console.Write(' ');
         
         // Draw playerCoordinates
         Console.SetCursorPosition(playerCoordinates.Item2, playerCoordinates.Item1);
         Console.BackgroundColor = player.Color;
         Console.Write(' ');
         Console.SetCursorPosition(50,21);
         Console.BackgroundColor = originalColor;
     }

     public void Move(string key, Player player)
     {
         // Get coordinates of player
         var coordinates = FindCoordinates(player.GridValue);
         var newCoordinates = (999, 999);
       
         
         // PlayerOne new coordinates
         if (key == "up") newCoordinates = (coordinates.Item1 - 1, coordinates.Item2);
         
         if (key == "down") newCoordinates = (coordinates.Item1 + 1, coordinates.Item2);
         
         if (key == "left") newCoordinates = (coordinates.Item1, coordinates.Item2 - 1);

         if (key == "right") newCoordinates = (coordinates.Item1, coordinates.Item2 + 1);
         
         // PlayerTwo new coordinates
         if (key == "W") newCoordinates = (coordinates.Item1 - 1, coordinates.Item2);
         
         if (key == "S") newCoordinates = (coordinates.Item1 + 1, coordinates.Item2);
         
         if (key == "A") newCoordinates = (coordinates.Item1, coordinates.Item2 - 1);

         if (key == "D") newCoordinates = (coordinates.Item1, coordinates.Item2 + 1);
         
         
         if (IsCoin(player, newCoordinates) || IsPath(newCoordinates) || IsPortal(player, newCoordinates))
         {
            Redraw(coordinates, player, newCoordinates);
            // Update grid
            Grid[coordinates.Item1, coordinates.Item2] = 1;
            Grid[newCoordinates.Item1, newCoordinates.Item2] = player.GridValue;
         }
     }

     private static bool IsPath((int, int) newPlayerCoordinates)
     {
         //Get value at coordinate
         var gridValue = Grid[newPlayerCoordinates.Item1, newPlayerCoordinates.Item2];

         if (gridValue == 1)
         {
             return true;
         }
         // False = no path!   
         return false;
     }

     private bool IsPortal(Player player, (int, int) newPlayerCoordinates)
     {
         //Get value at coordinate
         var gridValue = Grid[newPlayerCoordinates.Item1, newPlayerCoordinates.Item2];

         if (gridValue == 5 && player.Id == 1)
         {
             Game.DeclareWinner(player);
             return true;
         }
         if (gridValue == 6 && player.Id == 2)
         {
             Game.DeclareWinner(player);
             return true;
         }
         return false;
     }

     private bool IsCoin(Player player, (int, int) newPlayerCoordinates)
     {
         //Get value at coordinate
         var gridValue = Grid[newPlayerCoordinates.Item1, newPlayerCoordinates.Item2];

         if (gridValue == 4)
         {
             // Add point to player
             player.AddToScore(10);
             if (player.Score == 100)
             {
                 SpawnPortal(player);
             }
             return true;
         }
         // False = no coin!   
         return false;
     }
     private static (int, int) FindCoordinates(int value)
     {
         var coordinates = (0, 0);
         // Loop for each row
         for (var row = 0; row < RowCount; row++)
         {
             // Loop for each column
             for (var col = 0; col < ColCount; col++)
             {
                 if (Grid[row, col] == value)
                 {
                     coordinates = (row, col);
                 }
             }
         }

         return coordinates;
     }

     private void SpawnPortal(Player player)
     {
         //Spawn portal
         var rnd = new Random();
         int row = rnd.Next(2, 19);
         int col = rnd.Next(1, 49);
         if (player.Id == 1)
         {
            Grid[row, col] = 5;
         }
         if (player.Id == 2)
         {
            Grid[row, col] = 6;
         }
         // Add extra paths around portal
         Grid[row - 1, col] = 1;
         Grid[row + 1, col] = 1;
         Grid[row, col + 1] = 1;
         Grid[row, col - 1] = 1;
         Draw();
     }
}