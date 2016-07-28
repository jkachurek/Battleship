using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBattleship.BLL;
using SuperBattleship.BLL.Requests;
using SuperBattleship.BLL.Responses;

namespace SuperBattleship.UI
{
    public class ShotPrompts
    {
        public static bool TakeTurns(Player player1, Player player2)
        {
            while (!TakeShot(player1, player2) && !TakeShot(player2, player1))
                return false;
            return true;
        }

        public static bool TakeShot(Player currentPlayer, Player enemyPlayer)
        {
            ConsoleIO.TextPrompt($"{currentPlayer.Name}, press enter to start your turn.");
            DrawUI.DrawEnemyBoard(enemyPlayer);
            Coordinate input = ConsoleIO.ConvertStringToCoordinate("shot");
            FireShotResponse newShot = enemyPlayer.PlayerBoard.FireShot(input);
            while (newShot.ShotStatus == ShotStatus.Invalid || newShot.ShotStatus == ShotStatus.Duplicate)
            {
                if (newShot.ShotStatus == ShotStatus.Invalid)
                {
                    Console.WriteLine("That location isn't on the board!");
                    input = ConsoleIO.ConvertStringToCoordinate("shot");
                    newShot = enemyPlayer.PlayerBoard.FireShot(input);
                }
                else
                {
                    ConsoleIO.Print("You have already fired at that location!");
                    input = ConsoleIO.ConvertStringToCoordinate("shot");
                    newShot = enemyPlayer.PlayerBoard.FireShot(input);
                }
            }
            #region Shot Status Switch
            switch (newShot.ShotStatus)
            {
                case ShotStatus.Miss:
                    DrawUI.DrawEnemyBoard(enemyPlayer);
                    ConsoleIO.Print("Miss!");
                    break;
                case ShotStatus.Hit:
                    DrawUI.DrawEnemyBoard(enemyPlayer);
                    ConsoleIO.Print("Hit!");
                    break;
                case ShotStatus.HitAndSunk:
                    DrawUI.DrawEnemyBoard(enemyPlayer);
                    ConsoleIO.Print($"Hit!  You've sunk {enemyPlayer.Name}'s {newShot.ShipImpacted}!");
                    break;
                case ShotStatus.Victory:
                    DrawUI.DrawEnemyBoard(enemyPlayer);
                    ConsoleIO.Print($"Hit!  You've sunk {enemyPlayer.Name}'s last ship, the {newShot.ShipImpacted}!\n" +
                                      $"{currentPlayer.Name} wins!\n");
                    return true;
            }
            #endregion
            
            ConsoleIO.TextPrompt("Press enter to see your board");
            DrawUI.DrawBoard(currentPlayer);
            ConsoleIO.EnterAndClear("Press enter to end your turn");
            return false;
        }
    }
}
