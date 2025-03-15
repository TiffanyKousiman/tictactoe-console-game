using static System.Console;

namespace TicTacToe
{
    public abstract class Helper
    {
        public void listCommands()
        {
            WriteLine("m - place a piece on the board at the specified row and column (row, col)");
            WriteLine("u - Undo the last move");
            WriteLine("r - Redo the last undone move");
            WriteLine("s - Save the game to continue from where you left.");
            WriteLine("? - How to interpret board");
            WriteLine();
        }

        public abstract void showGameRule();

        public abstract void interpretBoard();
    }
}
