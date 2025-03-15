using static System.Console;

namespace TicTacToe
{
    public class TicTacToeHelper : Helper
    {

        public override void showGameRule()
        {
            WriteLine(">>>>>> Tic-Tac-Toe Game Rules <<<<<<\n");
            WriteLine(">> A player can undo and redo to make changes to their move. " +
                "If one wants to undo multiple steps backwards, the last move being undone has to be their own piece.");
            WriteLine(">> Game can be saved at any point of the game and loaded to be replayable");
            WriteLine(">> The first player to fill a row with their marks wins.");
            WriteLine(">> Player can choose to compete against a computer player or another human.");
            WriteLine(">> Only human player can undo and redo.");
            WriteLine(">> If no player has won and all the board cells are occupied, " +
                "the game has been drawn.");

            WriteLine();
            WriteLine("Possible winning conditions on a 3x3 board:\n");
            showWinStateHoriztonal();
            showWinStateVertical();
            showWinStateDiagonal();
        }

        private void showWinStateDiagonal()
        {
            WriteLine("Win diagonally:");
            WriteLine(" X |   |   ");
            WriteLine("--- --- ---");
            WriteLine("   | X |   ");
            WriteLine("--- --- ---");
            WriteLine("   |   | X ");
            WriteLine();
        }

        private void showWinStateHoriztonal()
        {
            WriteLine("Win horizontally:");
            WriteLine(" X | X | X ");
            WriteLine("--- --- ---");
            WriteLine("   |   |   ");
            WriteLine("--- --- ---");
            WriteLine("   |   |   ");
            WriteLine();
        }

        private void showWinStateVertical()
        {
            WriteLine("Win Vertically:");
            WriteLine(" X |   |   ");
            WriteLine("--- --- ---");
            WriteLine(" X |   |   ");
            WriteLine("--- --- ---");
            WriteLine(" X |   |   ");
            WriteLine();
        }

        public override void interpretBoard()
        {
            WriteLine("    0   1   2 ");
            WriteLine(" 0    |   |   ");
            WriteLine("   --- --- ---");
            WriteLine(" 1    |   | X ");
            WriteLine("   --- --- ---");
            WriteLine(" 2    |   |   ");
            WriteLine();
            WriteLine("The piece X is placed on row 1 and column 2, therefore enter [1,2] to make a move.");

        }
    }
}
