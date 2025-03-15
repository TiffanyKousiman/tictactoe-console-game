using static System.Console;

namespace TicTacToe
{
    public abstract class Game
    {
        protected GameStatus currentState;
        protected Board board;
        protected Player currentPlayer;
        protected Queue<Player> players;
        protected Helper helper;
        protected CommandManager commandManager;
        protected string gameName;


        // game properties
        protected string GameName { set { gameName = value; } }
        public GameMode GameMode { get; set; }
        public Board Board { get { return board; } }
        public Player CurrentPlayer { get { return currentPlayer; } set { currentPlayer = value; } }
        public Queue<Player> Players { get { return players; } set { players = value; } }


        public Game(IGameFactory factory)
        {
            board = factory.createBoard();
            helper = factory.createHelper();
            players = factory.createPlayers();
            commandManager = CommandManager.getCommandManager();
            currentState = GameStatus.PLAYING;
        }

        public void play()
        {
            /* this is a template method for all the game instances, and has an active life since 
             * a player selects start game or load game after navigating menu, to the end of the game when 
             * a game has found a tie, a winner or when save game is prompted */

            do
            {
                Clear();

                // return and remove the first player from the queue
                currentPlayer = players.Dequeue();

                // print player's turn
                WriteLine(">>>>>> It's {0}'s turn <<<<<<", currentPlayer.Id);

                // print current board
                board.printBoard();

                // parse play command
                parsePlayCommand();
                Clear();

                // print current board
                board.printBoard();

                // update current state and check winner
                updateGameStatus();

                //add player in
                players.Enqueue(currentPlayer);

            } while (currentState == GameStatus.PLAYING);
        }

        public virtual void updateGameStatus()
        {
            /* after a valid move has been made onto the board, this method will be 
             * called after each player's turn to update game status by 
             * first checking whether someone has won the game 
             * otherwise check tie to see if the board is completely filled and yet no player can be found */

            if (hasWon(currentPlayer.getInputRow(), currentPlayer.getInputCol(), currentPlayer.Piece))
            {
                if (currentPlayer.Id == "Player 1")
                    currentState = GameStatus.PLAYER1_WON;
                else if (currentPlayer.Id == "Player 2")
                    currentState = GameStatus.PLAYER2_WON;
                WriteLine(currentPlayer.Id + " has won the game," +
                    "restart the program to replay.");
            }
            else if (hasDrawn())
            {
                currentState = GameStatus.DRAW;
                WriteLine("It is a cat game, restart the program to replay.");
            }
        }

        private void parsePlayCommand()
        {
            /* 
             * (1) save game, pressed by player of their turn.
             * (2) undo a move, upon the player of their turn entering a move, previous player can still undo a move.
             * (3) redo a move, upon the player of their turn entering a move, previous player can still redo a move.
             * (4) make a move, is when the player takes a move at their turn */

            helper.listCommands();

            bool isExecuted = false;

            while (isExecuted == false)
            {
                Write("Enter a command: ");
                if (char.TryParse(ReadLine(), out char command))
                {
                    command = char.ToUpper(command);
                    switch (command)
                    {
                        case 'S':
                            {
                                saveGame();
                                isExecuted = true;
                            }
                            break;
                        case '?':
                            helper.interpretBoard();
                            WriteLine();
                            break;
                        case 'U':
                            if (commandManager.isUndoAvailable())
                            {
                                commandManager.undo();
                                WriteLine("The most recent move has been undone.");
                                WriteLine();
                                isExecuted = true;
                            }
                            else
                                WriteLine("No move left to undo.");
                            break;
                        case 'R':
                            if (commandManager.isRedoAvailable())
                            {
                                commandManager.redo();
                                WriteLine("The most recent undo has been redone.");
                                WriteLine();
                                isExecuted = true;
                            }
                            else
                                WriteLine("No undos left to redo.");
                            break;
                        case 'M':
                            Write("Enter row,col: ");
                            getPlayerMove();
                            isExecuted = true;
                            break;
                        default:
                            WriteLine("Invalid command.");
                            break;
                    }
                }
                else
                {
                    WriteLine("Invalid command.");
                    helper.listCommands();
                }
            }
        }

        private void getPlayerMove()
        {
            /* prompt player to make a move */
            currentPlayer.makeValidMove(board);
        }

        protected abstract bool hasDrawn();
        protected abstract bool hasWon(int row, int col, PlayingPiece piece);

        private void saveGame()
        {
            /* game properties to be saved:
              * (1) game states: board states - calling board.ToString() which returns the rows and cols of the occupied cells in a string 
              * (2) player turn: currentPlayer
              * (3) game mode: Human vs Human and Human vs Computer
              * for the purpose of this game, a constant FILENAME is created which will be used when a game is loaded back in
              * hence, only one game can be saved at runtime, and a new game will override the existing one in the same directory */

            const char DELIM = '|';
            string fileName = gameName + ".txt";

            FileStream outFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);
            writer.WriteLine(board.ToString() + DELIM + board.Row + DELIM + board.Col +
                DELIM + currentPlayer.Id + DELIM + GameMode.ToString());
            WriteLine("\nGame saved successfully, press any key to exit the game");
            writer.Close();
            outFile.Close();
            ReadKey();
            Environment.Exit(0);
        }
    }
}