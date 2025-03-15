namespace TicTacToe
{
    public abstract class Player
    {
        // latest input position to be referenced by the game in checking game status
        protected int inputRow, inputCol;
        public int getInputRow() { return inputRow; }
        public int getInputCol() { return inputCol; }

        // the piece of a player 
        public PlayingPiece Piece { get; private set; }

        // The display id of the player
        public string Id { get; private set; }

        // initialize and create new player
        public Player(string id, PlayingPiece piece)
        {
            this.Piece = piece;
            this.Id = id;
        }
        public abstract void makeValidMove(Board board);
    }
}