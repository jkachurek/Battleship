using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBattleship.BLL.Requests;
using SuperBattleship.BLL.Responses;
using SuperBattleship.BLL.Ships;

namespace SuperBattleship.BLL.GameLogic
{
    public class Board
    {
        // PROPERTIES
        // Added by me
        // This is the array that is the actual game board
        // I added this here so that it is closely associated with the game board, but can also
        // be instantiated along with each new player.
        public string[,] GameBoard = new string[10, 10];

        // Default properties
        public Dictionary<Coordinate, ShotHistory> ShotHistory;
        private Ship[] _Ships;
        private int _currentShipIndex;

        // CONSTRUCTOR
        public Board()
        {
            ShotHistory = new Dictionary<Coordinate, ShotHistory>();
            _Ships = new Ship[5];
            _currentShipIndex = 0;
        }

        // Verifies the result of the shot the player has chosen.
        public FireShotResponse FireShot(Coordinate coordinate)
        {
            var response = new FireShotResponse();

            // is this coordinate on the board?
            if (!IsValidCoordinate(coordinate))
            {
                response.ShotStatus = ShotStatus.Invalid;
                return response;
            }

            // did they already try this position?
            if (ShotHistory.ContainsKey(coordinate))
            {
                response.ShotStatus = ShotStatus.Duplicate;
                return response;
            }
            CheckShipsForHit(coordinate, response);

            // Added by me
            // This code tells the game to write "hit" or "miss" icons in the space where
            // the player has fired, based on the shot status.  It uses the ternary
            // operator.
            GameBoard[coordinate.YCoordinate, coordinate.XCoordinate] =
                (response.ShotStatus == ShotStatus.Hit) ||
                (response.ShotStatus == ShotStatus.HitAndSunk) ||
                (response.ShotStatus == ShotStatus.Victory) ? "H" : "M";

            CheckForVictory(response);

            return response;
        }

        // Checks victory conditions; Are all Ships sunk?
        private void CheckForVictory(FireShotResponse response)
        {
            if (response.ShotStatus == ShotStatus.HitAndSunk)
            {
                // did they win?
                if (_Ships.All(s => s.IsSunk))
                    response.ShotStatus = ShotStatus.Victory;
            }
        }

        private void CheckShipsForHit(Coordinate coordinate, FireShotResponse response)
        {
            response.ShotStatus = ShotStatus.Miss;

            foreach (var Ship in _Ships)
            {
                // no need to check sunk Ships
                if (Ship.IsSunk)
                    continue;

                ShotStatus status = Ship.FireAtShip(coordinate);

                switch (status)
                {
                    case ShotStatus.HitAndSunk:
                        response.ShotStatus = ShotStatus.HitAndSunk;
                        response.ShipImpacted = Ship.ShipName;
                        ShotHistory.Add(coordinate, Responses.ShotHistory.Hit);
                        break;
                    case ShotStatus.Hit:
                        response.ShotStatus = ShotStatus.Hit;
                        response.ShipImpacted = Ship.ShipName;
                        ShotHistory.Add(coordinate, Responses.ShotHistory.Hit);
                        break;
                }

                // if they hit something, no need to continue looping
                if (status != ShotStatus.Miss)
                    break;
            }

            if (response.ShotStatus == ShotStatus.Miss)
            {
                ShotHistory.Add(coordinate, Responses.ShotHistory.Miss);
            }
        }

        // Ensures that the coords entered are actually on the board
        // Because of my Coordinate conversion method, this method is never actually used

        private bool IsValidCoordinate(Coordinate coordinate)
        {
            return coordinate.XCoordinate >= 0 && coordinate.XCoordinate <= 9 &&
            coordinate.YCoordinate >= 0 && coordinate.YCoordinate <= 9;
        }

        // Places Ship for player
        public ShipPlacement PlaceShip(PlaceShipRequest request)
        {
            // This next bit of code is unused because of a condition that I added
            if (_currentShipIndex > 4)
                throw new Exception("You can not add another Ship, 5 is the limit!");

            if (!IsValidCoordinate(request.Coordinate))
                return ShipPlacement.NotEnoughSpace;

            // I added AlreadyPlaced to the ShipPlacement Enum to make sure ships are not placed twice.
            // This verifies whether or not a Ship type has been placed already
            if (AlreadyPlaced(request.ShipType))
                return ShipPlacement.AlreadyPlaced;


            // This is where the Ship actually gets placed.  The switch determines which direction
            // the Ship faces from the given coordinate.
            Ship newShip = ShipCreator.CreateShip(request.ShipType);
            switch (request.Direction)
            {
                case ShipDirection.Down:
                    return PlaceShipDown(request.Coordinate, newShip);
                case ShipDirection.Up:
                    return PlaceShipUp(request.Coordinate, newShip);
                case ShipDirection.Left:
                    return PlaceShipLeft(request.Coordinate, newShip);
                default:
                    return PlaceShipRight(request.Coordinate, newShip);
            }
        }

        private ShipPlacement PlaceShipRight(Coordinate coordinate, Ship newShip)
        {
            // x coordinate gets bigger
            int positionIndex = 0;
            int maxX = coordinate.XCoordinate + newShip.BoardPositions.Length;



            for (int i = coordinate.XCoordinate; i < maxX; i++)
            {
                var currentCoordinate = new Coordinate(i, coordinate.YCoordinate);

                GameBoard[coordinate.YCoordinate, coordinate.XCoordinate] = "O";

                if (!IsValidCoordinate(currentCoordinate))
                {
                    return ShipPlacement.NotEnoughSpace;
                }

                if (OverlapsAnotherShip(currentCoordinate))
                {
                    return ShipPlacement.Overlap;
                }

                newShip.BoardPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }

            AddShipToBoard(newShip);
            return ShipPlacement.Ok;
        }

        private ShipPlacement PlaceShipLeft(Coordinate coordinate, Ship newShip)
        {
            // x coordinate gets smaller
            int positionIndex = 0;
            int minX = coordinate.XCoordinate - newShip.BoardPositions.Length;

            for (int i = coordinate.XCoordinate; i > minX; i--)
            {
                var currentCoordinate = new Coordinate(i, coordinate.YCoordinate);

                GameBoard[coordinate.YCoordinate, coordinate.XCoordinate] = "O";

                if (!IsValidCoordinate(currentCoordinate))
                {
                    return ShipPlacement.NotEnoughSpace;
                }

                if (OverlapsAnotherShip(currentCoordinate))
                {
                    return ShipPlacement.Overlap;
                }

                newShip.BoardPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }

            AddShipToBoard(newShip);
            return ShipPlacement.Ok;
        }

        private ShipPlacement PlaceShipUp(Coordinate coordinate, Ship newShip)
        {
            // y coordinate gets smaller
            int positionIndex = 0;
            int minY = coordinate.YCoordinate - newShip.BoardPositions.Length;

            for (int i = coordinate.YCoordinate; i > minY; i--)
            {
                var currentCoordinate = new Coordinate(coordinate.XCoordinate, i);

                if (!IsValidCoordinate(currentCoordinate))
                {
                    return ShipPlacement.NotEnoughSpace;
                }

                if (OverlapsAnotherShip(currentCoordinate))
                {
                    return ShipPlacement.Overlap;
                }

                newShip.BoardPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }

            AddShipToBoard(newShip);
            return ShipPlacement.Ok;
        }

        private ShipPlacement PlaceShipDown(Coordinate coordinate, Ship newShip)
        {
            // y coordinate gets bigger
            int positionIndex = 0;
            int maxY = coordinate.YCoordinate + newShip.BoardPositions.Length;

            for (int i = coordinate.YCoordinate; i < maxY; i++)
            {
                var currentCoordinate = new Coordinate(coordinate.XCoordinate, i);

                if (!IsValidCoordinate(currentCoordinate))
                {
                    return ShipPlacement.NotEnoughSpace;
                }

                if (OverlapsAnotherShip(currentCoordinate))
                {
                    return ShipPlacement.Overlap;
                }

                newShip.BoardPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }

            AddShipToBoard(newShip);
            return ShipPlacement.Ok;
        }

        // Increases index of Ships on the board by 1; called within the ShipPlacement method.
        private void AddShipToBoard(Ship newShip)
        {
            _Ships[_currentShipIndex] = newShip;
            _currentShipIndex++;
            //Added by me.  Bool saying this Ship type has already been placed.
            newShip.AlreadyPlaced = true;
        }

        // Determines if a Ship location touches another Ship; if so, it throws
        // an exception in the PlaceShip method.
        private bool OverlapsAnotherShip(Coordinate coordinate)
        {
            foreach (var Ship in _Ships)
            {
                if (Ship != null)
                {
                    if (Ship.BoardPositions.Contains(coordinate))
                        return true;
                }
            }

            return false;
        }


        // METHODS ADDED BY ME

        // This method determines if a specific ship type has been placed already
        public bool AlreadyPlaced(ShipType newShipType)
        {
            foreach (var ship in _Ships)
            {
                // Null Propagation Operator!  It's useful!
                // It determines that an input is valid before it performs an operation on it
                if (ship?.ShipType == newShipType)
                    return true;
            }
            return false;
        }

        // This method determines if all ships have been placed.  The ship index will
        // only increment if a ship gets placed successfully.
        public bool AllShipsPlaced()
        {
            foreach (var Ship in _Ships)
                if (Ship != null)
                {
                    if (_currentShipIndex == 5)
                        return true;
                }
            return false;
        }

        // Opposite of all ships placed!  This is a bool for when the ship index on a board
        // returns to zero, meaning the game is over.  I do not actually use this because of the
        // PlayAgain method, but it is important to have as part of the do while loop for taking turns.
        public bool GameOver()
        {
            return _currentShipIndex == 0;
        }
    }
}
