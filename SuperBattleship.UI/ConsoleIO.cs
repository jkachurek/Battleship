using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBattleship.BLL;
using SuperBattleship.BLL.Requests;
using SuperBattleship.BLL.Ships;

namespace SuperBattleship.UI
{
    public static class ConsoleIO
    {
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        public static void EnterAndClear(string message)
        {
            Print(message);
            Console.ReadLine();
            Console.Clear();
        }

        public static void TextPrompt(string prompt)
        {
            Print(prompt);
            Console.ReadLine();
        }

        public static string InputPrompt(string message)
        {
            Print(message);
            return Console.ReadLine();
        }

        // Method containing the While loop for validating input.  Param 1 is the input from the player,
        // Param 2 is the text prompt for what they need to input correctly.
        public static string InputPrompt(Player currentPlayer, string inputType)
        {
            Print($"{currentPlayer.Name}, please enter your {inputType}.");
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Print($"Please enter a valid {inputType}.");
                input = Console.ReadLine();
            }
            return input;
        }

        // OVERLOAD: Takes a dictionary as an additional parameter
        public static string InputPrompt<T>(Player currentPlayer, string inputType, Dictionary<string, T> inputDictionary)
        {
            Print($"{currentPlayer.Name}, please enter your {inputType}.");
            string input = Console.ReadLine()?.ToLower();
            while (string.IsNullOrEmpty(input) || !inputDictionary.ContainsKey(input))
            {
                Print($"Please enter a valid {inputType}.");
                input = Console.ReadLine();
            }
            return input;
        }

        public static bool AlreadyDidThat(bool condition, string whatDidTheyDo)
        {
            if (condition)
            {
                Print(whatDidTheyDo);
                return true;
            }
            return false;
        }

        public static void DisplayShipBank(Player currentPlayer)
        {
            Print("What type of ship would you like to place?  Your options are:");
            foreach (var ship in currentPlayer.ShipBank)
                Print(ship.Value);
        }

        public static Coordinate ConvertStringToCoordinate(string shipOrShot)
        {
            Print($"Please enter an alphanumeric coordinate for your {shipOrShot}.");
            string input = Console.ReadLine();
            
            while (string.IsNullOrEmpty(input) || input.Length > 3 || input.Length < 2 ||
                          !InputDictionaries.letterCoordDictionary.ContainsKey(input.Substring(0, 1).ToUpper()) ||
                          !InputDictionaries.numCoordDictionary.ContainsKey(input.Substring(1)))
            {
                input = InputPrompt("Please enter a valid alphanumeric coordinate.");
            }

            return new Coordinate(InputDictionaries.letterCoordDictionary[input.Substring(0, 1).ToUpper()],
                                        InputDictionaries.numCoordDictionary[input.Substring(1)]);
        }

        public static void PlayAgain()
        {
            Console.WriteLine("Would you like to play again?\nType Yes, or press enter to exit.");
            string input = Console.ReadLine();
            if (InputDictionaries.PlayAgainInputs.Contains(input?.ToUpper()))
            {
                Console.Clear();
                GameWorkflow.Game();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
