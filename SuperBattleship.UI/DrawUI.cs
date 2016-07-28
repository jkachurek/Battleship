using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBattleship.BLL;
using SuperBattleship.BLL.GameLogic;
using SuperBattleship.BLL.Requests;
using SuperBattleship.BLL.Ships;

namespace SuperBattleship.UI
{
    class DrawUI
    {
        public static void NewBoard(Player currentPlayer)
        {
            int rowLength = currentPlayer.PlayerBoard.GameBoard.GetLength(0);
            int colLength = currentPlayer.PlayerBoard.GameBoard.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    currentPlayer.PlayerBoard.GameBoard[i, j] = "O";
                }
            }
        }
        // This method is used to draw the current player's board, with all things visible and regular 
        // color coding.
        public static void DrawBoard(Player currentPlayer)
        {
            // These two ints are shorthand for the dimensions of the 2D array
            int rowLength = currentPlayer.PlayerBoard.GameBoard.GetLength(0);
            int colLength = currentPlayer.PlayerBoard.GameBoard.GetLength(1);

            // There are a lot of spaces and separated bits of lines here; they are to ensure consistent
            // colors and formatting across the board.

            // These are labels to make the board clearer to players.
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                      YOUR BOARD                      ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("                  GAME BOARD LEGEND:                  ");
            Console.WriteLine("        O = Open Sea | H = Hit | M = Miss             \n" +
                              "        A = Aircraft Carrier | B = BattleShip         \n" +
                              "        C = Cruiser | D = Destroyer | S = Ship        \n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // Draws X Axis letter labels above the array
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("      A    B    C    D    E    F    G    H    I    J  ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            // This int is the Y axis label.  It increments after each loop through a row, such that
            // it prints the numbers 1 through 10 on the left side of the board.
            int y = 1;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                                                  ");

            // Iterates through each row of the board
            for (int i = 0; i < rowLength; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                // This is where the Y axis label actually gets written
                Console.Write(" {0,2} ", Convert.ToString(y));
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                // Iterates through each column in the current row.
                for (int j = 0; j < colLength; j++)
                {
                    // This switch changes the color of each spot on the board based upon the symbol
                    switch (currentPlayer.PlayerBoard.GameBoard[i, j])
                    {
                        // Boats: Gray background, green text
                        case "A":
                        case "B":
                        case "C":
                        case "D":
                        case "S":
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write($" {currentPlayer.PlayerBoard.GameBoard[i, j]} ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(" ");
                            break;
                        // Hits: Black background, red text
                        case "H":
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" {currentPlayer.PlayerBoard.GameBoard[i, j]} ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(" ");
                            break;
                        // Misses: Black background, yellow text
                        case "M":
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($" {currentPlayer.PlayerBoard.GameBoard[i, j]} ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Write(" ");
                            break;
                        // Open ocean: Default: Blue background, gray text
                        default:
                            Console.Write($"  {currentPlayer.PlayerBoard.GameBoard[i, j]}  ");
                            break;
                    }
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("    ");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("                                                  ");
                y++;
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        // This method is the same as DrawBoard, but it draws your enemy's board.  Instead of 
        // drawing ship symbols, however, this method draws "O"s for open ocean where the Ship
        // symbols would be located, thus hiding your enemy's ships.  These O's are still
        // overwritten by hits or misses, so it functions just like the top part of a real
        // Battleship board.
        public static void DrawEnemyBoard(Player enemyPlayer)
        {
            int rowLength = enemyPlayer.PlayerBoard.GameBoard.GetLength(0);
            int colLength = enemyPlayer.PlayerBoard.GameBoard.GetLength(1);

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                      ENEMY BOARD                     ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("                  GAME BOARD LEGEND:                  ");
            Console.WriteLine("        O = Open Sea | H = Hit | M = Miss             \n" +
                              "        A = Aircraft Carrier | B = BattleShip         \n" +
                              "        C = Cruiser | D = Destroyer | S = Ship        \n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // Draws X Axis letter labels above the array
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("      A    B    C    D    E    F    G    H    I    J  ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            // This int is the Y axis label.  It increments after each loop through a row, such that
            // it prints the numbers 1 through 10 on the left side of the board.
            int y = 1;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("    ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("                                                  ");

            // Iterates through each row of the board
            for (int i = 0; i < rowLength; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                // This is where the Y axis label actually gets written
                Console.Write(" {0,2} ", Convert.ToString(y));
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                for (int j = 0; j < colLength; j++)
                {
                    // This switch changes the color of the spot on the board based upon the symbol
                    switch (enemyPlayer.PlayerBoard.GameBoard[i, j])
                    {
                        // To draw your enemy board, instead of drawing the actual Ships, it replaces
                        // any Ship symbols with the default open ocean symbol, "O"
                        // Boats
                        case "A":
                        case "B":
                        case "C":
                        case "D":
                        case "S":
                            Console.Write("  O  ");
                            //Console.Write(" ");
                            //Console.BackgroundColor = ConsoleColor.Gray;
                            //Console.ForegroundColor = ConsoleColor.DarkGreen;
                            //Console.Write($" {GameBoard[i, j]} ");
                            //Console.ForegroundColor = ConsoleColor.Gray;
                            //Console.BackgroundColor = ConsoleColor.DarkBlue;
                            //Console.Write(" ");
                            break;
                        // Hits
                        case "H":
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" {enemyPlayer.PlayerBoard.GameBoard[i, j]} ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" ");
                            break;
                        // Misses
                        case "M":
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($" {enemyPlayer.PlayerBoard.GameBoard[i, j]} ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" ");
                            break;
                        // Open ocean
                        default:
                            Console.Write($"  {enemyPlayer.PlayerBoard.GameBoard[i, j]}  ");
                            break;
                    }
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("    ");
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("                                                  ");
                y++;
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        //SHIP DRAW METHODS
        public static void DrawShip(Player currentPlayer, PlaceShipRequest request)
        {
            Ship newShip = ShipCreator.CreateShip(request.ShipType);
            switch (request.Direction)
            {
                case ShipDirection.Down:
                    DrawShipDown(request.Coordinate, newShip, currentPlayer);
                    break;
                case ShipDirection.Up:
                    DrawShipUp(request.Coordinate, newShip, currentPlayer);
                    break;
                case ShipDirection.Left:
                    DrawShipLeft(request.Coordinate, newShip, currentPlayer);
                    break;
                default:
                    DrawShipRight(request.Coordinate, newShip, currentPlayer);
                    break;
            }
        }
        private static void DrawShipRight(Coordinate coordinate, Ship newShip, Player currentPlayer)
        {
            int maxX = coordinate.XCoordinate + newShip.BoardPositions.Length;

            for (int i = coordinate.XCoordinate; i < maxX; i++)
            {
                var currentCoordinate = new Coordinate(i, coordinate.YCoordinate);
                currentPlayer.PlayerBoard.GameBoard[currentCoordinate.YCoordinate, currentCoordinate.XCoordinate] = $"{newShip.ShipSymbol}";
            }
        }
        private static void DrawShipLeft(Coordinate coordinate, Ship newShip, Player currentPlayer)
        {
            int minX = coordinate.XCoordinate - newShip.BoardPositions.Length;

            for (int i = coordinate.XCoordinate; i > minX; i--)
            {
                var currentCoordinate = new Coordinate(i, coordinate.YCoordinate);
                currentPlayer.PlayerBoard.GameBoard[currentCoordinate.YCoordinate, currentCoordinate.XCoordinate] = $"{newShip.ShipSymbol}";
            }
        }
        private static void DrawShipUp(Coordinate coordinate, Ship newShip, Player currentPlayer)
        {
            int minY = coordinate.YCoordinate - newShip.BoardPositions.Length;

            for (int i = coordinate.YCoordinate; i > minY; i--)
            {
                var currentCoordinate = new Coordinate(coordinate.XCoordinate, i);
                currentPlayer.PlayerBoard.GameBoard[currentCoordinate.YCoordinate, currentCoordinate.XCoordinate] = $"{newShip.ShipSymbol}";
            }
        }
        private static void DrawShipDown(Coordinate coordinate, Ship newShip, Player currentPlayer)
        {
            int maxY = coordinate.YCoordinate + newShip.BoardPositions.Length;

            for (int i = coordinate.YCoordinate; i < maxY; i++)
            {
                var currentCoordinate = new Coordinate(coordinate.XCoordinate, i);
                currentPlayer.PlayerBoard.GameBoard[currentCoordinate.YCoordinate, currentCoordinate.XCoordinate] = $"{newShip.ShipSymbol}";
            }
        }

    }
}
