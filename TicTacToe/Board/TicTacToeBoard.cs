using static System.Console;

namespace TicTacToe
{
    public class TicTacToeBoard : Board 
    {
        public TicTacToeBoard(int row) : base(row) { }

        public override void addPiece(int row, int col, PlayingPiece piece)
        {
            // add a piece in a tic-tac-toe way 
            // separated as a specialised method as the board state will correspond differently after a piece is added to the board
            // in TTT, it is only adding a piece to the grid without influencing the other cells' states
            board[row, col] = piece;
        }
    }
}