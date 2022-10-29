namespace cicho.CommandLine;

public abstract class CommandExecutor
{
    public List<string> Alisas = new();
    public abstract void Execute(string cmd, string[] args);
}