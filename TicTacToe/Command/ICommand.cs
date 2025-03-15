namespace TicTacToe
{
    public interface ICommand
    {
        public void execute();
        public void undo();
    }
}
