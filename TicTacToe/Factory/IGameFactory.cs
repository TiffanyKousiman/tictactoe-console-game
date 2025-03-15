namespace TicTacToe
{
    public interface IGameFactory
    {
        public abstract Board createBoard();
        public abstract Helper createHelper();
        public abstract Queue<Player> createPlayers();
    }
}
