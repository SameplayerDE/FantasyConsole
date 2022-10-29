namespace cicho_8.CommandLine.Commands;

public class ShutdownCommand : CommandExecutor
{

    public ShutdownCommand()
    {
        Alisas.Add("shut");
    }
    
    public override int Execute(string cmd, string[] args)
    {
        //shutdown
        VirtualSystem.Shutdown();
        return 0;
    }
}