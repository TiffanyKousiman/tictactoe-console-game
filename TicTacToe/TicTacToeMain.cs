using static System.Console;

/* a main class that offers a command-line way of 
 * playing the TicTacToe game *
 * 
 * authored by Si Man Kou N11200855 */

namespace TicTacToe
{
    public class TicTacToeMain
    {
        static void Main()
        {
            WriteLine("******************************************");
            WriteLine("** WELCOME TO TIFFANY'S PLAY STATION :) **");
            WriteLine("******************************************");

            WriteLine("\nOnly Tic Tac Toe game is available in our game repository, " +
                "press any key to enter game menu.");

            if (ReadLine() != null)
            {
                GameMenu menu = new TicTacToeGameMenu();
                menu.navigateMenu();            
            }

            ReadKey();
        }

    }
}