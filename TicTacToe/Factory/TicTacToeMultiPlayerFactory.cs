namespace TicTacToe
{
    public class TicTacToeMultiPlayerFactory : TicTacToeGameFactory
    {
        public override Queue<Player> createPlayers()
        {
            Queue<Player> players = new Queue<Player>();
            players.Enqueue(new HumanPlayer("Player 1", new PlayingPieceX()));
            players.Enqueue(new HumanPlayer("Player 2", new PlayingPieceO()));
            return players;
        }

    }
}
