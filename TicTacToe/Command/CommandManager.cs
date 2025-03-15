namespace TicTacToe
{
    public sealed class CommandManager
    {
        /* implements singleton pattern */

        public static CommandManager commandManager;

        private Stack<ICommand> undos = new Stack<ICommand>();
        private Stack<ICommand> redos = new Stack<ICommand>();
       
        public static CommandManager getCommandManager()
        {
            if (commandManager == null)
                commandManager = new CommandManager();
            return commandManager;
        }

        // check if undo and redo are available
        public bool isUndoAvailable()
        {
            return this.undos.Count > 0;
        }

        public bool isRedoAvailable()
        {
            return this.redos.Count > 0;
        }

        // execute a command
        public void executeCommand(ICommand command)
        {
            command.execute();
            this.undos.Push(command);
            this.redos.Clear();
        }

        // undo a command
        public void undo()
        {
            if (isUndoAvailable())
            {
                ICommand command = this.undos.Pop();
                command.undo();
                this.redos.Push(command);
            }
        }

        public void redo()
        {
            if (isRedoAvailable())
            {
                ICommand command = this.redos.Pop();
                command.execute();
                this.undos.Push(command);
            }
        }
    }
}
