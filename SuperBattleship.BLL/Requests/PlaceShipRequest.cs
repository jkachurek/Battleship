using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBattleship.BLL.Ships;

namespace SuperBattleship.BLL.Requests
{
    // Processes all input for placing a ship: where it is, which
    // direction it is facing, and what kind of ship it is.
    public class PlaceShipRequest
    {
        public Coordinate Coordinate { get; set; }
        public ShipDirection Direction { get; set; }
        public ShipType ShipType { get; set; }

        // CONSTRUCTORS
        public PlaceShipRequest(ShipType type, Coordinate coord, ShipDirection dir) { }

        public PlaceShipRequest() { }
    }
}
