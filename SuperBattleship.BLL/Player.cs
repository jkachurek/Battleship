using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBattleship.BLL.GameLogic;
using SuperBattleship.BLL.Ships;

namespace SuperBattleship.BLL
{
    public class Player
    {

        // This class holds all the details for each player

        // Properties

        public string Name { get; set; }
        // Each player has their own board that can be accessed separately
        public Board PlayerBoard { get; set; }
        public Dictionary<ShipType, string> ShipBank { get; set; }

        // Constructor
        // The parameter for this constructor is simply a string to be placed in the name prompt
        public Player(string defaultName)
        {
            Name = defaultName;
            // Creates a board specific to this player
            PlayerBoard = new Board();

            ShipBank = new Dictionary<ShipType, string>()
            {
                {ShipType.Carrier, "Carrier (5 spaces)" },
                {ShipType.Battleship, "Battleship (4 spaces)" },
                {ShipType.Cruiser, "Cruiser (3 spaces)" },
                {ShipType.Destroyer, "Destroyer (2 spaces)" },
                {ShipType.Submarine, "Submarine (3 spaces)" }
            };
        }



    }
}
