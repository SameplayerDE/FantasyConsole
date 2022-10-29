namespace cicho_8.CommandLine.Commands;

public class LoadCommand : CommandExecutor
{
    public override int Execute(string cmd, string[] args)
    {
        if (args.Length == 0)
        {
            return 0;
        }

        if (args.Length == 1)
        {
            try
            {
                ScriptHandler.Load(args[0]);
                Console.WriteLine("loaded file");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("could not load");
            }

            return 0;
        }
        return 1;
    }
}