using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBattleship.BLL;
using SuperBattleship.BLL.Requests;
using SuperBattleship.BLL.Responses;
using SuperBattleship.BLL.Ships;

namespace SuperBattleship.UI
{
    public class ShipPlacePrompts
    {
        public static ShipType NewShipType(Player currentPlayer)
        {
            ConsoleIO.DisplayShipBank(currentPlayer);
            string input = ConsoleIO.InputPrompt(currentPlayer, "ship type", InputDictionaries.ShipNames);
            
            while (ConsoleIO.AlreadyDidThat(!currentPlayer.ShipBank.ContainsKey(InputDictionaries.ShipNames[input]),
                        "You have already placed that ship."))
                input = ConsoleIO.InputPrompt(currentPlayer, "ship type", InputDictionaries.ShipNames);

            currentPlayer.ShipBank.Remove(InputDictionaries.ShipNames[input]);
            return InputDictionaries.ShipNames[input];
        }

        public static Coordinate NewShipCoordinate()
        {
            return ConsoleIO.ConvertStringToCoordinate("new ship");
        }

        public static ShipDirection NewShipDirection(Player currentPlayer)
        {
            string input = ConsoleIO.InputPrompt(currentPlayer, "ship direction", InputDictionaries.DirNames).ToLower();
            return InputDictionaries.DirNames[input];
        }

        public static PlaceShipRequest ShipPrompts(Player currentPlayer)
        {
            PlaceShipRequest newShip = new PlaceShipRequest();
            newShip.ShipType = NewShipType(currentPlayer);
            newShip.Coordinate = NewShipCoordinate();
            newShip.Direction = NewShipDirection(currentPlayer);
            return newShip;
        }

        public static void ShipPlaceResponses(Player currentPlayer)
        {
            do
            {
                DrawUI.DrawBoard(currentPlayer);
                PlaceShipRequest newShip = ShipPrompts(currentPlayer);
                switch (currentPlayer.PlayerBoard.PlaceShip(newShip))
                {
                    case ShipPlacement.Ok:
                        DrawUI.DrawShip(currentPlayer, newShip);
                        ConsoleIO.TextPrompt($"You have successfully placed your {newShip.ShipType}!\nPress any key to continue.");
                        break;
                    case ShipPlacement.AlreadyPlaced:
                        ConsoleIO.TextPrompt($"You've already placed your {newShip.ShipType}.  Please try again.");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        ConsoleIO.TextPrompt($"There's not enough space on the board to place your {newShip.ShipType} there.  Please try again.");
                        break;
                    case ShipPlacement.Overlap:
                        ConsoleIO.TextPrompt("That spot overlaps another ship.  Please try again.");
                        break;
                }
            } while (!currentPlayer.PlayerBoard.AllShipsPlaced());
        }

        public static void PlaceShips(Player currentPlayer, Player enemyPlayer)
        {
            ConsoleIO.EnterAndClear($"{currentPlayer.Name}, get ready to place your ships.");
            ShipPlaceResponses(currentPlayer);
            ConsoleIO.EnterAndClear($"{currentPlayer.Name}, all of your ships are placed!\n" +
                                     "Press enter to clear the screen, then pass the " +
                                    $"computer to {enemyPlayer.Name}.");
            ConsoleIO.EnterAndClear($"{enemyPlayer.Name}, press enter to continue.");
        }
    }
}
