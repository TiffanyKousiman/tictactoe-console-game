namespace TicTacToe
{
    public abstract class TicTacToeGameFactory : IGameFactory
    {
        public Board createBoard()
        {
            // call the constructor that accepts only one parameter
            // because tic tac toe uses a square board, assuming a standard 3 x 3 board for this assignment 
            // but can also be dynamically accepts user input.
            return new TicTacToeBoard(3);
        }
        public Helper createHelper()
        {
            // initialize tictactoe helper
            return new TicTacToeHelper();
        }
        public abstract Queue<Player> createPlayers();
    }
}
