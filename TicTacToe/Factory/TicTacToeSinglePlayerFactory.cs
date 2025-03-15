namespace TicTacToe
{
    public class TicTacToeSinglePlayerFactory : TicTacToeGameFactory
    {
        public override Queue<Player> createPlayers()
        {
            // human player is the first player who plays piece X
            // computer player plays piece o
            // returns a queue of player objects to be stored in the game class
            Queue<Player> players = new Queue<Player>();
            players.Enqueue(new HumanPlayer("Player 1", new PlayingPieceX()));
            players.Enqueue(new ComputerPlayer("Player 2", new PlayingPieceO()));
            return players;
        }
    }
}
