using static System.Console;

namespace TicTacToe
{
    public abstract class Board
    {
        protected PlayingPiece[,] board;
        public PlayingPiece[,] getBoard() { return board; }
        public int Row { get; set; }
        public int Col { get; set; }

        // constructor for game with unequal board width and length
        public Board(int row, int col)
        {
            Row = row;
            Col = col;
            this.board = new PlayingPiece[row, col];
        }

        // constructor for creating square board like tictactoe board
        public Board(int row)
        {
            Row = row;
            Col = row;
            this.board = new PlayingPiece[row, row];
        }
        
        // get the unoccupied cells stored as a list of tuples
        public List<Tuple<int, int>> getFreeCells()
        {
            List<Tuple<int, int>> freeCells = new List<Tuple<int, int>>();

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (board[i, j] == null)
                        freeCells.Add(new Tuple<int, int>(i, j));
                }
            }

            return freeCells;
        }

        // print board dynamically as per board dimension
        public void printBoard()
        {
            WriteLine();
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (board[i, j] != null)
                        Write(" " + board[i, j].pieceType + " ");
                    else
                        Write("   ");
                    if (j != Col - 1) 
                        Write("|");
                }
                if (i != Row - 1)
                {
                    WriteLine();
                    for (int j = 0; j < Col; j++)
                        Write("--- ");
                }
                WriteLine();
            }
            WriteLine();
        }

        // check whether a cell is empty or not,
        // returns true if it is empty
        private bool isCellEmpty(int row, int col)
        {
            return board[row, col] == null;
        }

        // check if a cell of user input row and col is within the board,
        // returns true if the cell is valid
        private bool isCellAvailable(int row, int col)
        {
            if ((row < 0 || row > Row - 1) || (col < 0 || col > Col - 1))
                return false;
            else 
                return true;
        }


        // check if board is fully filled, to used for checking draw state
        public bool isBoardFilled()
        {
            if (getFreeCells().Count == 0)
            {
                return true;
            }
            else
                return false;
        }

        // check if a move is valid or not 
        public bool isValidMove(int row, int col, PlayingPiece piece)
        {
            if (!isCellAvailable(row, col))
            {
                WriteLine("Cell {0}, {1} is not available on the board.", row, col);
                return false;
            }
            else if (!isCellEmpty(row, col))
            {
                WriteLine("Cell {0}, {1} is already filled.", row, col);
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            /* returns the string of board state for saving game */
            // board states are saved individually for each player in strings
            // player1's moves will be stored before player2
            // only the occupied positions as of current board state are saved, instead of saving the entire board

            string player1_pos = "";
            string player2_pos = "";

            const char DELIM = '|';

            // use loop to allow checking for occupied cells dynamically
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (board[i, j] != null)
                    {
                        if (board[i, j].pieceType == PieceType.X)
                            player1_pos += i.ToString() + "," + j.ToString() + "/"; // e.g. 1,2/2,2/ - player1_pos
                        else if (board[i, j].pieceType == PieceType.O)
                            player2_pos += i.ToString() + "," + j.ToString() + "/";
                    }
                }
            }

            // remove the last char "/" depending on the size of player1_pos and player2_pos arrays
            if (player1_pos.Length == 0 && player2_pos.Length > 0)
            {
                return player1_pos + DELIM + player2_pos.Remove(player2_pos.Length - 1, 1);
            }
            else if (player2_pos.Length == 0 && player1_pos.Length > 0)
            {
                return player1_pos.Remove(player1_pos.Length - 1, 1) + DELIM + player2_pos;
            }
            else if (player1_pos.Length == 0 && player2_pos.Length == 0)
            {
                return player1_pos + DELIM + player2_pos;
            }
            else
            {
                return player1_pos.Remove(player1_pos.Length - 1, 1) +
                DELIM + player2_pos.Remove(player2_pos.Length - 1, 1);
            }
        }

        // add valid piece once it is verified as a valid move
        public abstract void addPiece(int row, int col, PlayingPiece piece);
    }
}
