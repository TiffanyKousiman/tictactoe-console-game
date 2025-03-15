namespace TicTacToe
{
    public class TicTacToeGame : Game
    {
        public TicTacToeGame(IGameFactory factory): base(factory) {
            GameName = "TTTGame";
        }

        protected override bool hasDrawn()
        {
            /* tic tac toe game is a draw when the board is fully occupied */
            return board.isBoardFilled();
        }

        protected override bool hasWon(int row, int col, PlayingPiece piece)
        {
            bool rowMatch = true;
            bool colMatch = true;
            bool diagonalMatch = true;
            bool antiDiagonalMatch = true;

            for (int i = 0, k = 0; i < board.Row; i++, k++)
            {
                for (int j = 0; j < board.Col; j++)
                {
                    // check row 
                    if (board.getBoard()[row, j] == null || board.getBoard()[row, j].pieceType != piece.pieceType)
                        rowMatch = false;

                    // check column
                    if (board.getBoard()[j, col] == null || board.getBoard()[j, col].pieceType != piece.pieceType)
                        colMatch = false;

                    // check diagonals
                    if (board.getBoard()[i, k] == null || board.getBoard()[i, k].pieceType != piece.pieceType)
                        diagonalMatch = false;
                }
            }

            for (int i = 0, j = board.Row-1; i < board.Row; i++, j--)
            {
                // check antidiagonals
                if (board.getBoard()[j, i] == null || board.getBoard()[j, i].pieceType != piece.pieceType)
                {
                    antiDiagonalMatch = false;
                }
            }
            return rowMatch || colMatch || diagonalMatch || antiDiagonalMatch;
        }
    }
}
