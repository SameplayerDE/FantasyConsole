namespace cicho.CommandLine;

public class CommandLineHandler
{
    private static Dictionary<string, CommandExecutor> _executors = new Dictionary<string, CommandExecutor>();

    public static void Register(string command, CommandExecutor executor)
    {
        _executors.Add(command, executor);
    }
    
    public static int CheckCommand(Command command)
    {
        if (command.Cmd.Length == 0)
        {
            return -1;
        }

        foreach (var (key, executor) in _executors)
        {
            if (key != command.Cmd && !executor.Alisas.Contains(command.Cmd)) continue;
            executor.Execute(command.Cmd, command.Args);
            return 0;
        }

        return 1;
    }
}