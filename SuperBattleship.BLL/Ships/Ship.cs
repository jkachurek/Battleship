using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBattleship.BLL.Requests;
using SuperBattleship.BLL.Responses;

namespace SuperBattleship.BLL.Ships
{
    public class Ship
    {
        public ShipType ShipType { get; private set; }
        public string ShipName { get { return ShipType.ToString(); } }
        public Coordinate[] BoardPositions { get; set; }
        private int _lifeRemaining;
        public bool IsSunk { get { return _lifeRemaining == 0; } }

        // I ADDED THESE PROPERTIES
        // ShipSymbol is the string letter that will be written to the game board at the coordinates
        // that the ship occupies.
        public string ShipSymbol { get; set; }
        // AlreadyPlaced is a bool to ensure that duplicate ships cannot be placed.
        public bool AlreadyPlaced { get; set; }

        // I added shipSymbol as a parameter in the ship constructor, so we can set different
        // symbols for each ship
        public Ship(ShipType shipType, int numberOfSlots, string shipSymbol)
        {
            ShipType = shipType;
            _lifeRemaining = numberOfSlots;
            BoardPositions = new Coordinate[numberOfSlots];
            ShipSymbol = shipSymbol;
            AlreadyPlaced = false;
        }

        // Changes Shot Status based on whether or not a ship is present in the 
        // given coordinate
        public ShotStatus FireAtShip(Coordinate position)
        {
            if (BoardPositions.Contains(position))
            {
                _lifeRemaining--;

                if (_lifeRemaining == 0)
                    return ShotStatus.HitAndSunk;

                return ShotStatus.Hit;
            }

            return ShotStatus.Miss;
        }
    }
}
