using cicho_8.CommandLine;
using cicho_8.CommandLine.Commands;

namespace cicho_8;

public static class Program
{
    public static void Main()
    {
        var window = new GameWindow();
        window.Run();

        /*
        CommandLineHandler.Register("shutdown", new ShutdownCommand());
        CommandLineHandler.Register("load", new LoadCommand());
        CommandLineHandler.Register("run", new RunCommand());
        CommandLineHandler.Register("cls", new ClearCommand());

        VirtualSystem.Boot();   
        while (VirtualSystem.IsRunning)
        {
            Console.Write("> ");
            var command = new Command(Console.ReadLine()!.ToLower());
            var result = CommandLineHandler.CheckCommand(command);
            if (result > 1)
            {
                Console.WriteLine("syntax error");
            }
        }
        */
    }
}