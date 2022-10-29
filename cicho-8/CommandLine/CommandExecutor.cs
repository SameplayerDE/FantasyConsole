namespace cicho_8.CommandLine;

public abstract class CommandExecutor
{
    public List<string> Alisas = new();
    public abstract int Execute(string cmd, string[] args);
}