using static System.Console;

namespace TicTacToe
{
    public abstract class GameMenu
    {

        private const int LOADGAME = 1;
        private const int STARTGAME = 2;
        private const int SHOWRULE = 3;

        private const int HUMAN_HUMAN = (int) GameMode.HUMAN_HUMAN + 1;
        private const int HUMAN_COMPUTER = (int) GameMode.HUMAN_COMPUTER + 1;

        public void navigateMenu()
        {
            /* used as template method for all concrete GameMenu objects
             * write game introduction to the user then prompt the user to select: 
             *      load game/ start game/ show rules */

            Clear();
            introduction();
            WriteLine();
            menuCommands();
            WriteLine();

            bool isValid = false;
            while (isValid == false)
            {
                if (int.TryParse(ReadLine(), out int input))
                {
                    switch (input)
                    {
                        case LOADGAME:
                            {
                                bool isLoad = loadGame();
                                if (isLoad == false)
                                    WriteLine("No game is available for loading. Please choose other menu items:");
                                else
                                    isValid = true;
                                break;
                            }
                        case STARTGAME:
                            {
                                Clear();
                                startGame();
                                isValid = true;
                                break;
                            }
                        case SHOWRULE:
                            {
                                Clear();
                                showRule();
                                WriteLine("\npress any key to return to game menu.");
                                if (ReadLine() != null)
                                    navigateMenu(); // called recursively to ensure user will be brought back to game menu and select other menu options
                                break;
                            }
                        default:
                            {
                                WriteLine("Invalid input, please enter again:");
                                break;
                            }
                    }
                }
                else WriteLine("Invalid input, please enter again:");
            }
        }

        private void showRule()
        {
            /* create a helper object then call its showGameRule() to display game rules 
             * initialiseHelper is unique to each GameMenu, hence helper and game rules are both specific to a game */

            Helper helper = initialiseHelper();
            helper.showGameRule();
        }

        private void startGame()
        {
            /* This method is used as an entry point to a new game. 
             * It initializes a concrete game object based on the player's choice of game mode:
             * Single player: Human vs Human, or 
             * Multiple players: Human vs Human */

            WriteLine("\nPlease select a game mode: ");
            WriteLine();
            printGameMode();
            WriteLine();

            int input;

            bool isValidInput = false;

            while (isValidInput == false)
            {
                if (int.TryParse(ReadLine(), out input))
                {
                    if (input == HUMAN_HUMAN)
                    {
                        isValidInput = true;
                        Game game = initialiseMultiPlayer();
                        game.play();
                    }
                    else if (input == HUMAN_COMPUTER)
                    {
                        isValidInput = true;
                        Game game = initialiseSinglePlayer();
                        game.play();
                    }
                    else
                    {
                        WriteLine("Invalid mode entered, please choose a mode again:");
                    }
                }
                else
                {
                    WriteLine("Invalid mode entered, please choose a mode again:");
                }
            }
        }

        private void menuCommands()
        {
            // available menu commands user select before a game is initialised and played.

            WriteLine("[{0}] - Continue save game", LOADGAME);
            WriteLine("[{0}] - Start a new game", STARTGAME);
            WriteLine("[{0}] - Show game rules", SHOWRULE);
        }

        private void printGameMode()
        {
            // game mode to be selected by user to determine what game to be created

            WriteLine("[{0}] - Human vs Human game", HUMAN_HUMAN);
            WriteLine("[{0}] - Human vs Computer game", HUMAN_COMPUTER);
        }

        // menu class abstract methods to be overridden by concrete GameMenu subclass
        protected abstract Helper initialiseHelper();
        protected abstract bool loadGame();
        protected abstract void introduction();
        protected abstract Game initialiseMultiPlayer();
        protected abstract Game initialiseSinglePlayer();
    }
}


