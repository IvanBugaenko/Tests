namespace SpaceBattle.Lib;

class MacroCommand: ICommand
{
    private List<ICommand> command_list;

    public MacroCommand(List<ICommand> command_list)
    {
        this.command_list = command_list;
    }

    public void Execute()
    {
        command_list.ForEach(cmd => cmd.Execute());
    }
}