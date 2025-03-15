using static System.Console;

namespace TicTacToe
{
    public class ComputerPlayer : Player
    {
        // constructor
        public ComputerPlayer(string id, PlayingPiece piece) : base(id, piece) { }

        // makes a random move on the board
        public override void makeValidMove(Board board)
        {
            // get unoccupied cells from the board
            List<Tuple<int, int>> validOptions = board.getFreeCells();

            // pick a random move from validOptions then assign them to row, col
            Random random = new Random();
            int index = random.Next(validOptions.Count);

            // assign and write moves to console
            inputRow = validOptions[index].Item1;
            inputCol = validOptions[index].Item2;
            WriteLine(" Computer's move : {0},{1}", inputRow, inputCol);

            // player is a client who creates and configures a MakeMoveCommand object to the Icommand interface
            ICommand command = new MakeMoveCommand(inputRow, inputCol, Piece, board);
            CommandManager.getCommandManager().executeCommand(command);
        }
    }
}