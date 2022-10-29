using System.Data;
using System.Text.RegularExpressions;
using cicho.CommandLine;
using cicho.CommandLine.Commands;

namespace cicho;

public static class Program
{
    public static void Main()
    {
        CommandLineHandler.Register("shutdown", new ShutdownCommand());

        VirtualSystem.Boot();   
        while (VirtualSystem.IsRunning)
        {
            Console.Write("> ");
            var command = new Command(Console.ReadLine().ToLower());
            var result = CommandLineHandler.CheckCommand(command);
            if (result != 0)
            {
                Console.WriteLine("syntax error");
            }
        }
    }
}