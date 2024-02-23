using System.Runtime.CompilerServices;

namespace ConsoleApp1;
public class Maze(Player playerOne, Player playerTwo)
{
    public Player PlayerOne { get; } = playerOne;
    public Player PlayerTwo { get; } = playerTwo;
    static Int32[,] Grid { get; set; } = {
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,2,0},
    {0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0},
    {0,4,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0},
    {0,1,0,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,0,1,1,1,1,1,1,4,1,0},
    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0},
    {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,4,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,0,1,1,4,1,0,1,1,1,0},
    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,1,0,0,0},
    {0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,4,1,1,1,1,1,0,1,0,1,0,1,1,0,0,0},
    {0,4,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,0},
    {0,1,1,0,1,0,1,1,1,1,1,0,0,0,0,0,0,0,1,0,1,4,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,4,1,1,1,0,1,0,1,0,0,0,0},
    {0,0,0,0,1,0,1,0,0,0,1,1,1,1,0,0,0,0,1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0},
    {0,1,4,1,1,0,1,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,0,1,0,1,4,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,0,1,0,0,0,0},
    {0,0,0,0,0,0,1,0,1,1,4,1,1,1,0,0,0,0,1,0,0,1,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0},
    {0,1,1,4,1,1,1,0,4,0,0,0,0,0,0,0,0,0,1,0,0,1,0,1,0,0,1,1,1,1,1,1,0,1,0,0,0,0,0,1,0,0,0,0,1,1,0,0,0,0},
    {0,1,0,0,0,0,4,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,1,0,0,0,0,1,0,1,1,1,1,1,0,1,0,0,0,0,1,0,0,0,0,0},
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
                     Console.BackgroundColor = playerOne.Color;
                    
                 }
                 else if (Grid[row, col] ==  3) // 3 = PlayerTwo
                 {
                     Console.BackgroundColor = playerTwo.Color;
                     
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
         
         
         if (CheckForCoin(player, newCoordinates) || CheckForPath(newCoordinates))
         {
            Redraw(coordinates, player, newCoordinates);
            // Update grid
            Grid[coordinates.Item1, coordinates.Item2] = 1;
            Grid[newCoordinates.Item1, newCoordinates.Item2] = player.GridValue;
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

     private bool CheckForCoin(Player player, (int, int) newPlayerCoordinates)
     {
         //Get value at coordinate
         var gridValue = Grid[newPlayerCoordinates.Item1, newPlayerCoordinates.Item2];

         if (gridValue == 4)
         {
             // Add point to player
             player.AddToScore(10);
             Console.SetCursorPosition(player.ScoreCursorPosition,22);
             Console.ForegroundColor = player.Color;
             Console.WriteLine($"{player.Name}: {player.Score}");
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
}