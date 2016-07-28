using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SuperBattleship.BLL;

namespace SuperBattleship.UI
{
    public class GameWorkflow
    {
        public static void Game()
        {
            bool gameOver = false;
            MainMenu.DrawLogo();
            MainMenu.GameIntro();

            // Establish the players, prompt for names
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            player1.Name = ConsoleIO.InputPrompt(player1, "name");
            player2.Name = ConsoleIO.InputPrompt(player2, "name");
            DrawUI.NewBoard(player1);
            DrawUI.NewBoard(player2);


            // Place Ships for each player
            ShipPlacePrompts.PlaceShips(player1, player2);
            ShipPlacePrompts.PlaceShips(player2, player1);

            // Take turns firing shots.  See prompts for details.
            // This method contains the exit method
            while (!gameOver)
                gameOver = ShotPrompts.TakeTurns(player1, player2);
            PlayAgain();
        }

        public static void PlayAgain()
        {
            string input = ConsoleIO.InputPrompt("Would you like to play again?");
            if (InputDictionaries.PlayAgainInputs.Contains(input.ToUpper()))
                Game();
        }
    }
}

