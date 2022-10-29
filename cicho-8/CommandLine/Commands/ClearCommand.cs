namespace cicho_8.CommandLine.Commands;

public class ClearCommand : CommandExecutor
{
    public override int Execute(string cmd, string[] args)
    {
        CommandLineHandler.ClearConsole();
        return 0;
    }
}