using static System.Console;

namespace TicTacToe
{
    public class TicTacToeGameMenu : GameMenu
    {
        protected override void introduction()
        {
            WriteLine(">>>>>> WELCOME TO TIC TAC TOE CONSOLE GAME <<<<<<");
        }

        protected override bool loadGame()
        {
            /* this method is called when the user chooses continue game option. 
             * it opens the saved game file, presenting the pre-save board state
             * and then starts the game from the loaded state as the console accepts 
             * a key from user */

            const char DELIM = '|';
            const string FILENAME = "TTTGame.txt";
            string recordIn;
            string[] fields;
            Game game;

            if (File.Exists(FILENAME))
            {
                FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                recordIn = reader.ReadLine();

                if (recordIn != null)
                {
                    fields = recordIn.Split(DELIM);

                    // loaded game states
                    string[] player1Move = fields[0].Split('/');
                    string[] player2Move = fields[1].Split('/');
                    int boardRow = Convert.ToInt16(fields[2]);
                    int boardCol = Convert.ToInt16(fields[3]);
                    string loadPlayer = fields[4];
                    string loadGameMode = fields[5];

                    // initialise game object
                    if (loadGameMode.Equals(GameMode.HUMAN_HUMAN.ToString()))
                        game = initialiseMultiPlayer();
                    else
                        game = initialiseSinglePlayer();

                    // set current player
                    if (loadPlayer.Equals("Player 2"))
                    {
                        game.CurrentPlayer = game.Players.Dequeue();
                        game.Players.Enqueue(game.CurrentPlayer);
                    }

                    // set board state
                    if (player1Move[0] != "")
                    {
                        foreach (string ele in player1Move)
                        {
                            int row = Convert.ToInt16(ele.Split(',')[0]);
                            int col = Convert.ToInt16(ele.Split(',')[1]);
                            game.Board.getBoard()[row, col] = new PlayingPieceX();
                        }
                    }

                    if (player2Move[0] != "")
                    {
                        foreach (string ele in player2Move)
                        {
                            int row = Convert.ToInt16(ele.Split(',')[0]);
                            int col = Convert.ToInt16(ele.Split(',')[1]);
                            game.Board.getBoard()[row, col] = new PlayingPieceO();
                        }
                    }

                    reader.Close();
                    inFile.Close();

                    Clear();
                    WriteLine(">>>>>> LOADED GAME <<<<<<");
                    game.Board.printBoard();

                    WriteLine("Press anywhere to resume game.");
                    if (ReadLine() != null)
                    {
                        Clear();
                        game.play();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected override Game initialiseMultiPlayer()
        {
            Game game = new TicTacToeGame(new TicTacToeMultiPlayerFactory());
            game.GameMode = GameMode.HUMAN_HUMAN;
            return game;
        }

        protected override Game initialiseSinglePlayer()
        {       
            Game game = new TicTacToeGame(new TicTacToeSinglePlayerFactory());
            game.GameMode = GameMode.HUMAN_COMPUTER;
            return game;
        }

        protected override Helper initialiseHelper()
        {
            return new TicTacToeHelper();
        }
    }
}
