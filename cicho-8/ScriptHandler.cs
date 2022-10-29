using cicho_8.CommandLine;
using NLua;

namespace cicho_8;

public static class ScriptHandler
{
    private static string _root;
    public static string ScriptPath = string.Empty;
    public static readonly Lua Lua;

    private static string[] _predefinedFunctions;
    private static Dictionary<string, LuaFunction> _referencedFunctions;

    static ScriptHandler()
    {
        Lua = new Lua();
        Setup();
    }

    private static void Setup()
    {
        _root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        _root = Path.Combine(_root, "cicho-8");
        Directory.CreateDirectory(_root);
        _predefinedFunctions = new[]
        {
            "_init",
            "_update"
        };
        _referencedFunctions = new Dictionary<string, LuaFunction>();
        RegisterFunctions();
    }
    
    public static void Load(string scriptPath)
    {
        if (!File.Exists(Path.Combine(_root, scriptPath)))
        {
            throw new FileNotFoundException();
        }   
        ScriptPath = Path.Combine(_root, scriptPath);
    }

    public static void Run(string args = "")
    {
        if (!File.Exists(ScriptPath))
        {
            throw new FileNotFoundException();
        }
        Lua.DoFile(ScriptPath);
    }

    private static void RegisterFunctions()
    {
        Lua.RegisterFunction("cls", typeof(CommandLineHandler).GetMethod("ClearConsole"));
        Lua.RegisterFunction("cpr", typeof(CommandLineHandler).GetMethod("PrintChar"));
    }
}