using static System.Console;

namespace TicTacToe
{
    public class HumanPlayer : Player
    {
        // create a human player object
        public HumanPlayer(string id, PlayingPiece piece) : base(id, piece) { }

        public override void makeValidMove(Board board)
        {
            bool isValidMove = false;

            // keeps prompting user to enter command until a valid move is given
            while (isValidMove == false)
            {
                string input = ReadLine();
                try
                {
                    if (!int.TryParse(input.Split(",")[0], out inputRow) ||
                    !int.TryParse(input.Split(",")[1], out inputCol))
                        Write("Invalid command input, please re-enter row, col: ");
                    else
                    {
                        isValidMove = board.isValidMove(inputRow, inputCol, Piece);
                        if (isValidMove)
                        {
                            ICommand command = new MakeMoveCommand(inputRow, inputCol, Piece, board);
                            CommandManager.getCommandManager().executeCommand(command);
                        }
                        else
                            Write("Please re-enter row, col: ");
                    }
                }
                catch {Write("Invalid command input, please re-enter row, col: "); }

            }
        }
    }
}