namespace ConsoleApp1;
public class Maze(Player playerOne, Player playerTwo, Game game)
{
    public Player PlayerOne { get; } = playerOne;
    public Player PlayerTwo { get; } = playerTwo;

    private Game Game { get; } = game;

    private static readonly Grid Grid = new();
    
    private static readonly int RowCount = Grid.Arr.GetLength(0);
    private static readonly int ColCount = Grid.Arr.GetLength(1);
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
         
         
                 if (Grid.Arr[row, col] ==  0) // 0 = walls
                 {
                     Console.BackgroundColor = ConsoleColor.Gray;
                    
                 }
                 else if (Grid.Arr[row, col] ==  1) // 1 = path
                 {
                     Console.BackgroundColor = ConsoleColor.Black;
                     
                 }
                 else if (Grid.Arr[row, col] ==  2) // 2 = PlayerOne
                 {
                     Console.BackgroundColor = PlayerOne.Color;
                    
                 }
                 else if (Grid.Arr[row, col] ==  3) // 3 = PlayerTwo
                 {
                     Console.BackgroundColor = PlayerTwo.Color;
                     
                 }
                 else if (Grid.Arr[row, col] ==  4) // 4 = coin
                 {
                     Console.BackgroundColor = ConsoleColor.Yellow;
                     
                 }
                 else if (Grid.Arr[row, col] ==  5) // 5 = portal for playerOne
                 {
                     Console.BackgroundColor = PlayerOne.Color;
                 }
                 else if (Grid.Arr[row, col] ==  6) // 6 = portal for playerTwo
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
            Grid.Arr[coordinates.Item1, coordinates.Item2] = 1;
            Grid.Arr[newCoordinates.Item1, newCoordinates.Item2] = player.GridValue;
         }
     }

     private static bool IsPath((int, int) newPlayerCoordinates)
     {
         //Get value at coordinate
         var gridValue = Grid.Arr[newPlayerCoordinates.Item1, newPlayerCoordinates.Item2];

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
         var gridValue = Grid.Arr[newPlayerCoordinates.Item1, newPlayerCoordinates.Item2];

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
         var gridValue = Grid.Arr[newPlayerCoordinates.Item1, newPlayerCoordinates.Item2];

         if (gridValue == 4)
         {
             // Add point to player
             player.AddToScore(1);
             if (player.Score == 10)
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
                 if (Grid.Arr[row, col] == value)
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
         var row = rnd.Next(1, 21);
         var col = rnd.Next(1, 49);
         Grid.Arr[row, col] = player.Id switch
         {
             1 => 5,
             2 => 6,
             _ => Grid.Arr[row, col]
         };
         // Add extra paths around portal
         Grid.Arr[row - 1, col] = 1;
         Grid.Arr[row + 1, col] = 1;
         Grid.Arr[row, col + 1] = 1;
         Grid.Arr[row, col - 1] = 1;
         Draw();
     }
}