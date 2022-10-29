namespace cicho_8.CommandLine;

public struct Command
{
    public string Cmd;
    public string[] Args;

    public Command(string raw)
    {
        var temp = raw.Split(null);
        Cmd = temp[0];
        Args = temp[1..];
    }
}