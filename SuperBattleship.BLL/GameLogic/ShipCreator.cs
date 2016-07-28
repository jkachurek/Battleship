using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBattleship.BLL.Ships;

namespace SuperBattleship.BLL.GameLogic
{
    public class ShipCreator
    {
        public static Ship CreateShip(ShipType type)
        {
            // I added Ship Symbols as a property to the Ship class, then
            // added the symbol to the Ship constructor.  This way, each
            // ship type has its own string symbol that can be written to
            // the board.
            switch (type)
            {
                case ShipType.Destroyer:
                    return new Ship(ShipType.Destroyer, 2, "D");
                case ShipType.Cruiser:
                    return new Ship(ShipType.Cruiser, 3, "C");
                case ShipType.Submarine:
                    return new Ship(ShipType.Submarine, 3, "S");
                case ShipType.Battleship:
                    return new Ship(ShipType.Battleship, 4, "B");
                default:
                    return new Ship(ShipType.Carrier, 5, "A");
            }
        }
    }
}
