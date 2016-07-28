using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBattleship.BLL.Requests
{
    public class Coordinate
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }


        // CONSTRUCTORS, CONSTRUCTORS EVERYWHERE
        public Coordinate(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        // I added this empty constructor.  It is used for the ConvertStringToCoordinate method
        public Coordinate() { }

        // This method converts a string input to a Coordinate.  It is not as compact as it ought to be,
        // but it functions very well.  Even though creating dictionaries for both the letters AND the 
        // numbers is longer than just parsing the numbers out of the string, it actually makes validating
        // Coordinate inputs very, very easy.  Simply say that anything not in the dictionaries is invalid,
        // and you don't actually have to validate input anywhere else. 
        //public static Coordinate ConvertStringToCoordinate()
        //{
        //    // I use a goto statement & label here because I am a terrible human being
        //    InputCoord:
        //    string input = Console.ReadLine();
        //    Coordinate output = new Coordinate();
        //    string iupper = input.ToUpper();

        //    // Here we establish dictionaries so it can translate input
        //    Dictionary<string, int> letterCoordDictionary = new Dictionary<string, int>()
        //    {
        //        {"A", 0},{"B", 1},{"C", 2},{"D", 3},{"E", 4},{"F", 5},{"G", 6},{"H", 7},{"I", 8},{"J", 9}
        //    };
        //    Dictionary<string, int> numCoordDictionary = new Dictionary<string, int>()
        //    {
        //        {"1", 0},{"2", 1},{"3", 2},{"4", 3},{"5", 4},{"6", 5},{"7", 6},{"8", 7},{"9", 8},{"10", 9}
        //    };


        //    // This If statement is the only validation that I need for Coordinates in the game,
        //    // since it actually runs before the coordinates are fed into any other functions.
        //    // Conditions that trigger this are strings longer than 3 or shorter than 2, or if either
        //    // substring ((0,1) or (1)) is not a key in the dictionary.  This is where the dictionaries
        //    // make validation easy.
        //    if (input.Length > 3 || input.Length < 2 ||
        //                  !letterCoordDictionary.ContainsKey(iupper.Substring(0, 1)) ||
        //                  !numCoordDictionary.ContainsKey(iupper.Substring(1)))
        //    {
        //        Console.WriteLine("Please enter a valid alphanumeric coordinate.");
        //        goto InputCoord;
        //    }

        //    return new Coordinate(letterCoordDictionary[iupper.Substring(0, 1)],
        //                                numCoordDictionary[iupper.Substring(1)]);
        //}

        // Overrides a function of Equals to make the game logic function
        public override bool Equals(object obj)
        {
            Coordinate otherCoordinate = obj as Coordinate;

            if (otherCoordinate == null)
                return false;

            return otherCoordinate.XCoordinate == this.XCoordinate &&
                   otherCoordinate.YCoordinate == this.YCoordinate;
        }

        // Don't screw with this; It's confusing, but it's here to make this stuff work.
        public override int GetHashCode()
        {
            string uniqueHash = this.XCoordinate.ToString() + this.YCoordinate.ToString() + "00";
            return (Convert.ToInt32(uniqueHash));
        }

    }
}
