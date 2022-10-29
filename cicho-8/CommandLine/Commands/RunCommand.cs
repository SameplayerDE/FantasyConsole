namespace cicho_8.CommandLine.Commands;

public class RunCommand : CommandExecutor
{
    public override int Execute(string cmd, string[] args)
    {
        try
        {
            ScriptHandler.Run();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("could not run file");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        return 0;
    }
}