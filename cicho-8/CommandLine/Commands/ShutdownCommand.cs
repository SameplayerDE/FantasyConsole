namespace cicho.CommandLine.Commands;

public class ShutdownCommand : CommandExecutor
{

    public ShutdownCommand()
    {
        Alisas.Add("shut");
    }
    
    public override void Execute(string cmd, string[] args)
    {
        //shutdown
        VirtualSystem.Shutdown();
    }
}