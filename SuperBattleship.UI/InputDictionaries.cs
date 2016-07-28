using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBattleship.BLL.Requests;
using SuperBattleship.BLL.Responses;
using SuperBattleship.BLL.Ships;

namespace SuperBattleship.UI
{
    public static class InputDictionaries
    {
        public static Dictionary<string, ShipType> ShipNames = new Dictionary<string, ShipType>()
        {
            { "a",ShipType.Carrier}, {"carrier", ShipType.Carrier}, { "aircraft carrier", ShipType.Carrier},
            { "b", ShipType.Battleship}, { "battleship", ShipType.Battleship},
            { "c", ShipType.Cruiser}, { "cruiser", ShipType.Cruiser},
            { "d", ShipType.Destroyer}, { "destroyer", ShipType.Destroyer},
            { "s", ShipType.Submarine}, { "submarine", ShipType.Submarine}, { "e", ShipType.Submarine}
        };
        public  static Dictionary<string, ShipDirection> DirNames = new Dictionary<string, ShipDirection>()
        {
            {"u", ShipDirection.Up}, {"up",ShipDirection.Up },
            {"d", ShipDirection.Down }, {"down", ShipDirection.Down },
            {"l", ShipDirection.Left }, {"left", ShipDirection.Left },
            {"r", ShipDirection.Right}, {"right", ShipDirection.Right}
        };

        // Coordinate Dictionaries
        public static Dictionary<string, int> letterCoordDictionary = new Dictionary<string, int>()
            {
                {"A", 0},{"B", 1},{"C", 2},{"D", 3},{"E", 4},{"F", 5},{"G", 6},{"H", 7},{"I", 8},{"J", 9}
            };
        public static Dictionary<string, int> numCoordDictionary = new Dictionary<string, int>()
            {
                {"1", 0},{"2", 1},{"3", 2},{"4", 3},{"5", 4},{"6", 5},{"7", 6},{"8", 7},{"9", 8},{"10", 9}
            };

        public static List<string> PlayAgainInputs = new List<string>()
            {
                "Y", "YES", "SURE", "OK", "OKAY"
            };
    }
}
