using System.Runtime.CompilerServices;

namespace ConsoleApp1;
public class Maze(Player playerOne)
{
    private Player PlayerOne { get; } = playerOne;
    static Int32[,] Grid { get; set; } = {
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,3},
    {0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0},
    {0,4,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0},
    {0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,1,0},
    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0},
    {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,0,1,1,1,1,0,1,1,1,0},
    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,1,0,0,0},
    {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,1,1,0,0,0},
    {0,4,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0},
    {0,1,1,0,1,0,1,1,1,1,1,0,0,0,0,0,0,0,1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,0,0,0},
    {0,0,0,0,1,0,1,0,0,0,1,1,1,1,0,0,0,0,1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0},
    {0,1,4,1,1,0,1,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,0,1,0,0,0,0},
    {0,0,0,0,0,0,1,0,1,1,4,1,1,1,0,0,0,0,1,0,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0},
    {0,1,1,4,1,1,1,0,4,0,0,0,0,0,0,0,0,0,1,0,0,1,0,1,0,0,1,1,1,1,1,1,0,1,0,0,0,0,0,1,0,0,0,0,1,1,0,0,0,0},
    {0,1,0,0,0,0,4,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,1,0,0,0,0,1,0,1,1,1,1,1,0,1,0,0,0,0,1,0,0,0,0,0},
    {0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,0,0},
    {0,4,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,1,1,1,1,1,4,1,0},
    {0,1,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,4,1,0},
    {0,2,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0},
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
                 else if (Grid[row, col] ==  2) // 2 = hero
                 {
                     Console.BackgroundColor = ConsoleColor.Green;
                    
                 }
                 else if (Grid[row, col] ==  3) // 3 = baddie
                 {
                     Console.BackgroundColor = ConsoleColor.Red;
                     
                 }
                 else if (Grid[row, col] ==  4) // 4 = coin
                 {
                     Console.BackgroundColor = ConsoleColor.Yellow;
                     
                 }
                 Console.Write(' '); // Write a space to actually change the background color
                 Console.BackgroundColor = originalColor;
             }
         }
     }

     private static void Redraw((int, int) path, (int, int) player)
     { 
         // Console.WriteLine($"Trying to redraw path at left:{path.Item2} and top {path.Item1}");
         var originalColor = Console.BackgroundColor;
         
         // Draw path
         Console.BackgroundColor = ConsoleColor.Black;
         Console.SetCursorPosition(path.Item2, path.Item1);
         Console.Write(' ');
         
         // Draw player
         Console.SetCursorPosition(player.Item2, player.Item1);
         Console.BackgroundColor = ConsoleColor.Green;
         Console.Write(' ');
         Console.SetCursorPosition(50,21);
         Console.BackgroundColor = originalColor;
     }

     public void Move(string key)
     {
         // Get coordinates of player (2)
         var coordinates = FindCoordinates(Grid, 2);
         var newPlayerCoordinates = (999, 999);
         
         if (key == "up")
         {
             newPlayerCoordinates = (coordinates.Item1 - 1, coordinates.Item2);
         }

         if (key == "down")
         {
             newPlayerCoordinates = (coordinates.Item1 + 1, coordinates.Item2);
         }

         if (key == "left")
         {
             newPlayerCoordinates = (coordinates.Item1, coordinates.Item2 - 1);
         }

         if (key == "right")
         {
             newPlayerCoordinates = (coordinates.Item1, coordinates.Item2 + 1);
         }
         
         if (CheckForCoin(newPlayerCoordinates) || CheckForPath(newPlayerCoordinates))
         {
            Redraw(coordinates, newPlayerCoordinates);
            // Update grid
            Grid[coordinates.Item1, coordinates.Item2] = 1;
            Grid[newPlayerCoordinates.Item1, newPlayerCoordinates.Item2] = 2;
         }
     }

     private static bool CheckForPath((int, int) newPlayerCoordinates)
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

     private bool CheckForCoin((int, int) newPlayerCoordinates)
     {
         //Get value at coordinate
         var gridValue = Grid[newPlayerCoordinates.Item1, newPlayerCoordinates.Item2];

         if (gridValue == 4)
         {
             // Add point to player
             PlayerOne.AddToScore(10);
             Console.SetCursorPosition(0,22);
             Console.WriteLine($"{PlayerOne.Name}: {PlayerOne.Score}");
             return true;
         }
         // False = no coin!   
         return false;
     }
     private static (int, int) FindCoordinates(int[,] array, int value)
     {
         var coordinates = (0, 0);
         // Loop for each row
         for (var row = 0; row < RowCount; row++)
         {
             // Loop for each column
             for (var col = 0; col < ColCount; col++)
             {
                 if (Grid[row, col] == 2)
                 {
                     coordinates = (row, col);
                 }
             }
         }

         return coordinates;
     }
}