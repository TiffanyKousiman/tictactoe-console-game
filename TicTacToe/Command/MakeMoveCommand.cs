namespace TicTacToe
{
    public class MakeMoveCommand : ICommand
    {
        private int row, col;
        private PlayingPiece piece, previousPiece;
        private Board board;

        public MakeMoveCommand(int row, int col, PlayingPiece piece, Board board)
        {
            this.row = row;
            this.col = col;
            this.piece = piece;
            this.board = board;
            this.previousPiece = board.getBoard()[row, col];
        }

        public void execute()
        {
            board.addPiece(row, col, piece);
        }

        public void undo()
        {
            board.addPiece(row, col, previousPiece);
        }
    }
}
